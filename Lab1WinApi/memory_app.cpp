#include "memory_app.h"

std::wstring const MemoryApp::s_class_name{ L"MEMORY APP GAME" };

MemoryApp::MemoryApp(HINSTANCE instance, int n) : instance{ instance }, main_wnd{}, board{ n }, 
field_brush{ CreateSolidBrush(RGB(124, 10, 2)) },
screen_size{ .x = GetSystemMetrics(SM_CXSCREEN), .y = GetSystemMetrics(SM_CYSCREEN) }, game_state{ BEFORE_GAME_START } {
	srand(time(NULL));
	child_wnds = std::vector<ChildWnd>();
	board_size = {
		.left = 0,
		.top = 0,
		.right = board.width,
		.bottom = board.height
	};
	register_class();
	DWORD main_style = WS_OVERLAPPED | WS_SYSMENU | WS_CAPTION | WS_MINIMIZEBOX | WS_CLIPCHILDREN;
	// WS_EX_COMPOSITED for no flicker
	main_wnd = create_window(main_style);
}

int MemoryApp::run(int show_cmd) {
	ShowWindow(main_wnd, show_cmd);
	SetTimer(main_wnd, 0, 1000, nullptr);
	MSG msg{};
	BOOL result = TRUE;
	while ((result = GetMessageW(&msg, nullptr, 0, 0)) != 0) {
		if (result == -1) {
			return EXIT_FAILURE;
		}
		TranslateMessage(&msg);
		DispatchMessageW(&msg);
	}
	return EXIT_SUCCESS;
}

bool MemoryApp::register_class() { 
	WNDCLASSEXW desc{};
	if (GetClassInfoExW(instance, s_class_name.c_str(), &desc) != 0) {
		return true;
	}
	desc = {
		.cbSize = sizeof(WNDCLASSEXW),
		.lpfnWndProc = window_proc_static,
		.hInstance = instance,
		.hCursor = LoadCursorW(nullptr, L"IDC_ARROW"),
		.hbrBackground = CreateSolidBrush(RGB(255, 253, 208)),
		.lpszClassName = s_class_name.c_str()
	};
	return RegisterClassExW(&desc) != 0;
}

LRESULT MemoryApp::window_proc_static(HWND window, UINT message, WPARAM wparam, LPARAM lparam) {
	MemoryApp* app = nullptr;
	if (message == WM_NCCREATE) {
		auto p = reinterpret_cast<LPCREATESTRUCTW>(lparam);
		app = static_cast<MemoryApp*>(p->lpCreateParams);
		SetWindowLongPtrW(window, GWLP_USERDATA, reinterpret_cast<LONG_PTR>(app));
	} else {
		app = reinterpret_cast<MemoryApp*>(GetWindowLongPtrW(window, GWLP_USERDATA));
	}
	if (app != nullptr) {
		return app->window_proc(window, message, wparam, lparam);
	}
	return DefWindowProcW(window, message, wparam, lparam);
}

LRESULT MemoryApp::window_proc(HWND win, UINT msg, WPARAM wparam, LPARAM lparam) {
	switch (msg) {
		case WM_CLOSE:
			DestroyWindow(win);
			return 0;
		case WM_DESTROY:
			if (win == main_wnd) {
				PostQuitMessage(EXIT_SUCCESS);
			}
			return 0;
		case WM_CTLCOLORSTATIC:
			return reinterpret_cast<INT_PTR>(field_brush);
		case WM_KEYDOWN:
			if (wparam == VK_ESCAPE) {
				switch (game_state) {
					case BEFORE_GAME_START:
						start_game();
						return 0;
					case GAME_OVER:
						restart_game();
						return 0;
				}
			}
			break;
		case WM_LBUTTONUP:
			on_mouse_button_up(lparam);
			return 0;
		case WM_TIMER:
			on_timer();
			return 0;
	}
	return DefWindowProcW(win, msg, wparam, lparam);
}

HWND MemoryApp::create_window(DWORD style, HWND parent, DWORD ex_style) {
	AdjustWindowRectEx(&board_size, style, false, 0);
	int width = board_size.right - board_size.left;
	int height = board_size.bottom - board_size.top;
	HWND window = CreateWindowExW(
		ex_style,
		s_class_name.c_str(),
		L"Press ESC to start",
		style,	
		(screen_size.x - width ) / 2, (screen_size.y - height) / 2,
		width, height,
		parent,
		nullptr,
		instance,
		this
	);
	for (auto& f : board.get_fields()) {
		HWND wnd = CreateWindowExW(
			0,
			L"STATIC",
			nullptr,
			WS_CHILD | WS_VISIBLE | SS_CENTER,
			f.pos.left, f.pos.top,
			f.pos.right - f.pos.left, f.pos.bottom - f.pos.top,
			window,
			nullptr,
			instance,
			nullptr
		);
		child_wnds.push_back(ChildWnd{
			.wnd = wnd,
			.pos = f.pos
			});
	}
	return window;
}

void MemoryApp::start_game() {
	hide_all_children();
	game_state = GameState::DISPLAYING_SEQ;
	addToSequence();
	cur_displayed_tile = 0;
}

void MemoryApp::restart_game() {
	cur_displayed_tile = 0;
	streak = 0;
	cur_seq.clear();
	start_game();
}

void MemoryApp::hide_all_children() {
	for (auto x : child_wnds) {
		ShowWindow(x.wnd, SW_HIDE);
	}
}

void MemoryApp::show_all_children() {
	for (auto x : child_wnds) {
		ShowWindow(x.wnd, SW_SHOW);
	}
}

void MemoryApp::on_timer() {
	switch (game_state) {
		case DISPLAYING_SEQ:
			SetWindowTextW(main_wnd, std::format(L"Score: {} Remember the sequence!", cur_seq.size() - 1).c_str());
			ShowWindow(child_wnds[cur_seq[cur_displayed_tile]].wnd, SW_SHOW);
			game_state = GameState::TILE_SHOWN;
			return;
		case TILE_SHOWN:
			ShowWindow(child_wnds[cur_seq[cur_displayed_tile++]].wnd, SW_HIDE);
			game_state = GameState::TILE_HIDDEN;
			return;
		case TILE_HIDDEN:
			if (cur_displayed_tile == cur_seq.size()) {
				SetWindowTextW(main_wnd, std::format(L"Score: {} Guess it!", cur_seq.size() - 1).c_str());
				game_state = GameState::GUESSING;
				streak = 0;
				cur_displayed_tile = 0;
				return;
			}
			ShowWindow(child_wnds[cur_seq[cur_displayed_tile]].wnd, SW_SHOW);
			game_state = GameState::TILE_SHOWN;
			return;
		case GUESSED_CORRECTLY:
			ShowWindow(child_wnds[cur_seq[streak]].wnd, SW_SHOW);
			game_state = GameState::GUESSED_CORRECTLY_SHOWN;
			return;
		case GUESSED_CORRECTLY_SHOWN:
			ShowWindow(child_wnds[cur_seq[streak++]].wnd, SW_HIDE);
			if (streak == cur_seq.size()) {
				addToSequence();
				game_state = GameState::DISPLAYING_SEQ;
				return;
			}
			game_state = GameState::GUESSING;
			return;
	}
}

void MemoryApp::addToSequence() {
	cur_seq.push_back(rand() % child_wnds.size());
}

void MemoryApp::on_mouse_button_up(LPARAM lparam) {
	if (game_state == GameState::GUESSING) {
		auto x = GET_X_LPARAM(lparam);
		auto y = GET_Y_LPARAM(lparam);
		HWND wnd = ChildWindowFromPoint(main_wnd, POINT(x, y));
		if (wnd == child_wnds[cur_seq[streak]].wnd) {
			if (streak > 0) {
				ShowWindow(child_wnds[cur_seq[streak - 1]].wnd, SW_HIDE);
			}
			ShowWindow(child_wnds[cur_seq[streak]].wnd, SW_SHOW);
			streak++;
		} else {
			game_state = GameState::GAME_OVER;
			std::wstring text = std::format(L"Score: {} Wrong! Press ESC to restart!", cur_seq.size() - 1);
			SetWindowTextW(main_wnd, text.c_str());
			show_all_children();
		}
		if (streak == cur_seq.size()) {
			streak--;
			game_state = GameState::GUESSED_CORRECTLY;
			KillTimer(main_wnd, 0);
			SetTimer(main_wnd, 0, 1000, nullptr);
		}
	}
}
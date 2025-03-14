#include "gdi_app.h"

std::wstring const GdiApp::s_class_name{ L"GDI Example" };

GdiApp::GdiApp(HINSTANCE instance) : instance{ instance }, main_wnd{}, screen_size{ .x = GetSystemMetrics(SM_CXSCREEN), .y = GetSystemMetrics(SM_CYSCREEN) }, window_rect{ .left = 0, .top = 0, .right = 800, .bottom = 600 } {
	srand(time(NULL));
	register_class();
	DWORD main_style = WS_OVERLAPPEDWINDOW | WS_SYSMENU | WS_CAPTION | WS_MINIMIZEBOX | WS_CLIPCHILDREN;
	// WS_EX_COMPOSITED for no flicker
	main_wnd = create_window(main_style);
}

int GdiApp::run(int show_cmd) {
	ShowWindow(main_wnd, show_cmd);
	SetTimer(main_wnd, 0, 16, nullptr);
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

bool GdiApp::register_class() {
	WNDCLASSEXW desc{};
	if (GetClassInfoExW(instance, s_class_name.c_str(), &desc) != 0) {
		return true;
	}
	desc = {
		.cbSize = sizeof(WNDCLASSEXW),
		.lpfnWndProc = window_proc_static,
		.hInstance = instance,
		.hCursor = LoadCursorW(nullptr, L"IDC_ARROW"),
		.hbrBackground = CreateSolidBrush(RGB(200, 200, 200)),
		.lpszClassName = s_class_name.c_str()
	};
	return RegisterClassExW(&desc) != 0;
}

LRESULT GdiApp::window_proc_static(HWND window, UINT message, WPARAM wparam, LPARAM lparam) {
	GdiApp* app = nullptr;
	if (message == WM_NCCREATE) {
		auto p = reinterpret_cast<LPCREATESTRUCTW>(lparam);
		app = static_cast<GdiApp*>(p->lpCreateParams);
		SetWindowLongPtrW(window, GWLP_USERDATA, reinterpret_cast<LONG_PTR>(app));
	}
	else {
		app = reinterpret_cast<GdiApp*>(GetWindowLongPtrW(window, GWLP_USERDATA));
	}
	if (app != nullptr) {
		return app->window_proc(window, message, wparam, lparam);
	}
	return DefWindowProcW(window, message, wparam, lparam);
}

LRESULT GdiApp::window_proc(HWND win, UINT msg, WPARAM wparam, LPARAM lparam) {
	switch (msg) {
		case WM_CLOSE:
			DestroyWindow(win);
			return 0;
		case WM_DESTROY:
			if (win == main_wnd) {
				PostQuitMessage(EXIT_SUCCESS);
			}
			return 0;
		case WM_PAINT:
			do_painting(win);
			return 0;
		case WM_ERASEBKGND:
			return 0;
		case WM_TIMER:
			InvalidateRect(win, nullptr, false);
	}
	return DefWindowProcW(win, msg, wparam, lparam);
}

HWND GdiApp::create_window(DWORD style, HWND parent, DWORD ex_style) {
	AdjustWindowRectEx(&window_rect, style, false, 0);
	int width = window_rect.right - window_rect.left;
	int height = window_rect.bottom - window_rect.top;
	HWND window = CreateWindowExW(
		ex_style,
		s_class_name.c_str(),
		L"Title",
		style,
		(screen_size.x - width) / 2, (screen_size.y - height) / 2,
		width, height,
		parent,
		nullptr,
		instance,
		this
	);
	return window;
}

void GdiApp::do_painting(HWND win) {
	int width = window_rect.right - window_rect.left;
	int height = window_rect.bottom - window_rect.top;
	

	PAINTSTRUCT ps;
	HDC dc = BeginPaint(win, &ps); // MANDATORY
	HDC mem_dc = CreateCompatibleDC(dc);
	HBITMAP mem_bmp = CreateCompatibleBitmap(dc, width, height);
	HBITMAP old_bmp = reinterpret_cast<HBITMAP>(SelectObject(mem_dc, mem_bmp));

	// int r = rand() % 256;
	// SetBkColor(mem_dc, RGB(r, r, r));
	int r = rand() % 100;
	HGDIOBJ bkg_brush = CreateSolidBrush(RGB(200, 200, 200));
	SelectObject(mem_dc, bkg_brush);
	FillRect(mem_dc, &ps.rcPaint, (HBRUSH)bkg_brush);
	HGDIOBJ brush1 = CreateSolidBrush(RGB(0, 162, 232)), brush2 = CreateSolidBrush(RGB(162, 128, 242));
	HGDIOBJ pen1 = CreatePen(PS_SOLID, 3, RGB(0, 16, 25)), pen2 = CreatePen(PS_DASH, 1, RGB(0X7F, 0, 0X7F));
	SelectObject(mem_dc, brush1);
	SelectObject(mem_dc, pen1);
	POINT p1[3] = { { r, 10 }, { 310, 150}, { 110, 150 } };
	// Outer triangle filled blue
	Polygon(mem_dc, p1, 3);
	SelectObject(mem_dc, brush2);
	POINT p2[10] = {
	{ 210, 30 }, { 250, 86 }, { 170, 86 }, // Small upper triangle
	{ 163, 98 }, { 258, 98 }, { 287, 138 }, { 133, 138 }, // Lower trapezoid
	{ 210, 50 }, { 156, 126 }, { 264, 126 } }; // Inner triangle
	INT c2[3] = { 3, 4, 3 };
	PolyPolygon(mem_dc, p2, c2, 3);

	SelectObject(mem_dc, pen2);
	SetBkColor(mem_dc, RGB(0X7F, 0X7F, 0));
	int rop2[16] = { R2_BLACK , R2_NOTMERGEPEN,
	R2_MASKNOTPEN , R2_NOTCOPYPEN , R2_MASKPENNOT ,
	R2_NOT, R2_XORPEN , R2_NOTMASKPEN ,
	R2_MASKPEN , R2_NOTXORPEN , R2_NOP,
	R2_MERGENOTPEN , R2_COPYPEN , R2_MERGEPENNOT ,
	R2_MERGEPEN , R2_WHITE };
	for (int i = 0; i < 16; ++i) {
		SetROP2(mem_dc, rop2[i]);
		MoveToEx(mem_dc, 2, i * 3 + 1, nullptr);
		LineTo(mem_dc, 38, i * 3 + 1);
	}

	BitBlt(dc, 0, 0, width, height, mem_dc, 0, 0, SRCCOPY);
	DeleteObject(SelectObject(mem_dc, old_bmp));
	DeleteObject(brush1);
	DeleteObject(brush2);
	DeleteObject(pen1);
	EndPaint(win, &ps); // MANDATORY

}
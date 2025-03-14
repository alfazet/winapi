#pragma once
#include <windowsx.h>
#include <string>
#include <chrono>
#include "board.h"

struct ChildWnd
{
	HWND wnd;
	RECT pos;
};

enum GameState
{
	BEFORE_GAME_START,
	DISPLAYING_SEQ,
	TILE_SHOWN,
	TILE_HIDDEN,
	GUESSING,
	GUESSED_CORRECTLY,
	GUESSED_CORRECTLY_SHOWN,
	GAME_OVER
};

class MemoryApp {
private:
	HINSTANCE instance;
	board board;
	RECT board_size;
	HWND main_wnd;
	HBRUSH field_brush;
	POINT screen_size;
	GameState game_state;
	std::vector<ChildWnd> child_wnds;
	std::vector<int> cur_seq;
	int seq_id = 0;
	int cur_displayed_tile = 0;
	int streak = 0;
	int score = 0;

	bool register_class();
	static std::wstring const s_class_name;
	static LRESULT CALLBACK window_proc_static(HWND wnd, UINT msg, WPARAM wparam, LPARAM lparam);
	LRESULT window_proc(HWND wnd, UINT msg, WPARAM wparam, LPARAM lparam);
	HWND create_window(DWORD style, HWND parent = nullptr, DWORD ex_style = 0);
	void start_game();
	void restart_game();
	void hide_all_children();
	void show_all_children();
	void on_timer();
	void addToSequence();
	void on_mouse_button_up(LPARAM lparam);
public:
	MemoryApp(HINSTANCE instance, int n);
	int run(int show_cmd);
};
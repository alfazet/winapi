#pragma once
#include <windows.h>
#include <windowsx.h>
#include <vector>
#include <string>
#include <chrono>

struct ChildWnd
{
	HWND wnd;
	RECT pos;
};

class GdiApp {
private:
	HINSTANCE instance;
	HWND main_wnd;
	POINT screen_size;
	RECT window_rect;

	bool register_class();
	static std::wstring const s_class_name;
	static LRESULT CALLBACK window_proc_static(HWND wnd, UINT msg, WPARAM wparam, LPARAM lparam);
	LRESULT window_proc(HWND wnd, UINT msg, WPARAM wparam, LPARAM lparam);
	HWND create_window(DWORD style, HWND parent = nullptr, DWORD ex_style = 0);

	void do_painting(HWND win);
public:
	GdiApp(HINSTANCE instance);
	int run(int show_cmd);
};
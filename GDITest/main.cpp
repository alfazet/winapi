#include "gdi_app.h"

int WINAPI wWinMain(HINSTANCE instance, HINSTANCE, LPWSTR cmdargs, int show_command) {
	GdiApp app{ instance };
	return app.run(show_command);
}
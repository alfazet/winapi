#include "memory_app.h"

int WINAPI wWinMain(HINSTANCE instance, HINSTANCE, LPWSTR cmdargs, int show_command) {
	int n = 3;
	std::wstring args = std::wstring(cmdargs);
	if (!args.empty()) {
		n = std::stoi(args);
		if (n < 3 || n > 10) {
			return EXIT_FAILURE;
		}
	}
	MemoryApp app{ instance, n };
	return app.run(show_command);
}
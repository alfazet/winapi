#pragma once
#include <windows.h>
#include <vector>

struct Field
{
	RECT pos;
	bool visible;
};

class board
{
private:
	static constexpr int field_size = 90;
	static constexpr int margin = 5;
	int n;
	int rows;
	int cols;
	int n_fields;
	std::vector<Field> fields;
public:
	int width;
	int height;
	const std::vector<Field> get_fields();
	board(int n);
};
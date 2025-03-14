#include "board.h"

const std::vector<Field> board::get_fields() {
	return fields;
}

board::board(int n): n { n }, rows { n }, cols { n } {
	n_fields = rows * cols;
	fields = std::vector<Field>();
	width = cols * (field_size + 2 * margin);
	height = rows * (field_size + 2 * margin);
	for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			RECT pos;
			pos.left = col * (field_size + 2 * margin) + margin;
			pos.top = row * (field_size + 2 * margin) + margin;
			pos.right = pos.left + field_size;
			pos.bottom = pos.top + field_size;
			fields.push_back(Field{ .pos = pos, .visible = true });
		}
	}
}

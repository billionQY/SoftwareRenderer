#include <fstream>
#include <sstream>

#include "Canvas.h"

#define INT2CHAR_BIT(num, bit) (unsigned char)(((num) >> (bit)) & 0xff)
#define INT2CHAR(num) INT2CHAR_BIT((num),0), INT2CHAR_BIT((num),8), INT2CHAR_BIT((num),16), INT2CHAR_BIT((num),24)

// bmp's color is bgra order
void Canvas::SavaBmp(std::vector<Vector4> &frameBuffer, int width, int height, std::string file)
{
	unsigned char buf[54] = { 'B', 'M', INT2CHAR(54 + width * height * 32), INT2CHAR(0), INT2CHAR(54), INT2CHAR(40), INT2CHAR(width), INT2CHAR(height), 1, 0, 32, 0 };
	std::ofstream ofs(file, std::ios_base::out | std::ios_base::binary);
	ofs.write((char *)buf, sizeof(buf));
	for (auto &color : frameBuffer) {
		buf[0] = (unsigned char)std::min(255, (int)(color.z * 255));
		buf[1] = (unsigned char)std::min(255, (int)(color.y * 255));
		buf[2] = (unsigned char)std::min(255, (int)(color.x * 255));
		buf[3] = (unsigned char)std::min(255, (int)(color.w * 255));
		ofs.write((char *)buf, 4);
	}
}

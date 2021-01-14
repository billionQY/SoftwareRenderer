#include "Device.h"

#define WIDTH 800
#define HEIGHT 600

Vector3 mesh[8] = {
	Vector3(-1, -1,  1),
	Vector3( 1, -1,  1),
	Vector3( 1,  1,  1),
	Vector3(-1,  1,  1),
	Vector3(-1, -1, -1),
	Vector3( 1, -1, -1),
	Vector3( 1,  1, -1),
	Vector3(-1,  1, -1),
};

int main()
{
	Device dev;
	dev.Init(WIDTH, HEIGHT);
	dev.Clear();

	dev.SetPixel(Vector3(100, 100, 10), Vector4(0, 255, 255, 0));

	Canvas cvs;
	cvs.SavaBmp(dev.frameBuffer, WIDTH, HEIGHT, "screenshot.bmp");
}

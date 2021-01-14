#include "Device.h"

void Device::Init(int w, int h)
{
	width = w;
	height = h;

	frameBuffer = std::vector<Vector4>(w * h, Vector4());
	depthBuffer = std::vector<float>(w * h, FLT_MAX);
}

void Device::Clear()
{
	for (int i = 0; i < frameBuffer.size(); i++)
		frameBuffer[i].Zero();

	for (int i = 0; i < depthBuffer.size(); i++)
		depthBuffer[i] = FLT_MAX;
}

bool Device::ZTest(const Vector3 &v)
{
	int x = (int)v.x;
	int y = (int)v.y;
	int z = (int)v.z;
	int index = x + y * width;
	return depthBuffer[index] >= z;
}

bool Device::ZWrite(const Vector3 &v)
{
	int x = (int)v.x;
	int y = (int)v.y;
	int z = (int)v.z;
	int index = x + y * width;
	return depthBuffer[index] = z;
}

void Device::Rasterize(const vector<Vector3> &mesh)
{
	
}

void Device::SetPixel(const Vector3 &v, const Vector4 &color)
{
	int x = v.x;
	int y = v.y;

	if (x < 0 || x >= width)
		return;

	if (y < 0 || y >= height)
		return;

	int index = x * y;
	frameBuffer[index] = color;
}

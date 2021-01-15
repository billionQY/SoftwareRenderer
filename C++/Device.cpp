#include "Device.h"
#include "tgaimage.h"

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

void Device::Rasterize(vector<Vector3> &mesh)
{
	std::vector<Vector3> pixels;
	Scanline(mesh[0], mesh[1], mesh[2], pixels);
	for (auto pixel : pixels)
	{
		SetPixel(pixel, Vector4(0, 255, 255, 255));
	}
}

// 扫描线
//    v3
// 	  -
// 	  - -
// vm -   - v2
// 	  - -
//    -
//    v1
// 将v1、v2、v3三个点按纵坐标y升序排列
// 分别扫描v1-v2-vm和v2-vm-v3两个三角形
void Device::Scanline(Vector3 &v1, Vector3 &v2, Vector3 &v3, std::vector<Vector3> &pixels)
{
	pixels.clear();

	// 排序 v1.y <= v2.y <= v3.y
	if (v1.y > v2.y) std::swap(v1, v2);
	if (v2.y > v3.y) std::swap(v2, v3);
	if (v1.y > v3.y) std::swap(v1, v3);

	// 屏幕坐标为整数，将v1、v2、v3的坐标化整
	int x1 = (int)v1.x, y1 = (int)v1.y, z1 = (int)v1.z;
	int x2 = (int)v2.x, y2 = (int)v2.y, z2 = (int)v2.z;
	int x3 = (int)v3.x, y3 = (int)v3.y, z3 = (int)v3.z;

	// v1、v2、v3两两纵坐标差异值，加1防止除零
	int diffY_12 = y2 - y1 + 1;
	int diffY_23 = y3 - y2 + 1;
	int diffY_13 = y3 - y1 + 1;

#pragma region v1-v2-vm
	for (int y = y1; y <= y2; y++)
	{
		// 左右边界步长比例
		float lhsScale = (float)(y - y1) / diffY_13;
		float rhsScale = (float)(y - y1) / diffY_12;

		// 左右边界Z值
		float lhsZ = z1 + (z3 - z1) * lhsScale;
		float rhsZ = z1 + (z2 - z1) * rhsScale;
		int diffZ_lr = rhsZ - lhsZ;

		// 左右边界X值
		int lhsX = (int)(x1 + (x3 - x1) * lhsScale);
		int rhsX = (int)(x1 + (x2 - x1) * rhsScale);
		if (lhsX > rhsX) std::swap(lhsX, rhsX);
		int diffX_lr = rhsX - lhsX;

		// 从左到右扫描
		for (int x = lhsX; x <= rhsX; x++)
		{
			float scale = (float)(x - lhsX) / diffX_lr;
			float z = lhsZ + diffZ_lr * scale;
			pixels.push_back(Vector3(x, y, z));
		}
	}
#pragma endregion

#pragma region v2-vm-v3
	for (int y = y2; y <= y3; y++)
	{
		// 左右边界步长比例
		float lhsScale = (float)(y - y1) / diffY_13;
		float rhsScale = (float)(y - y2) / diffY_23;

		// 左右边界Z值
		float lhsZ = z1 + (z3 - z1) * lhsScale;
		float rhsZ = z2 + (z3 - z2) * rhsScale;
		float diffZ_lr = rhsZ - lhsZ;

		// 左右边界X值
		int lhsX = (int)(x1 + (x3 - x1) * lhsScale);
		int rhsX = (int)(x2 + (x3 - x2) * rhsScale);
		if (lhsX > rhsX) std::swap(lhsX, rhsX);
		float diffX_lr = rhsX - lhsX;

		// 从左到右扫描
		for (int x = lhsX; x <= rhsX; x++)
		{
			float scale = (x - lhsX) / diffX_lr;
			float z = lhsZ + diffZ_lr * scale;
			pixels.push_back(Vector3(x, y, z));
		}
	}
#pragma endregion
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

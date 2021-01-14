#pragma once

#include <cstdio>
#include <vector>

#include "Canvas.h"
#include "Vector3.h"
#include "Vector4.h"

using namespace std;
class Device
{
public:
	void Init(int w, int h);
	void Clear();
	bool ZTest(const Vector3 &v);
	bool ZWrite(const Vector3 &v);
	void Rasterize(const vector<Vector3> &mesh);
	void SetPixel(const Vector3 &v, const Vector4 &color);

public:
	int width;
	int height;
	std::vector<Vector4> frameBuffer; // 帧缓冲
	std::vector<float> depthBuffer; // 深度缓冲
};



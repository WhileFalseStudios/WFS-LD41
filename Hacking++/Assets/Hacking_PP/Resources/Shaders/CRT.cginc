// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#ifndef CRT_INC
#define CRT_INC

struct appdata
{
	float4 vertex : POSITION;
	float2 uv : TEXCOORD0;
};

struct v2f
{
	float2 uv : TEXCOORD0;
	float4 vertex : SV_POSITION;
};

v2f vert(appdata v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.uv = v.uv;
	return o;
}

sampler2D _MainTex;

float2 distort(float co, float cube, float2 uv)
{
	if (cube == 0.0) return uv;

	float sub_r = uv.r - 0.5;
	float sub_g = uv.g - 0.5;

	float p = pow(sub_r, 2) + pow(sub_g, 2);

	return (uv - 0.5) * (1 + (p * (co + cube * sqrt(p)))) + 0.5;
}

float4 exclusion(float4 cBase, float4 cBlend, float alpha)
{
	return lerp(cBase, .5 - 2 * (cBase - .5) * (cBlend - .5), alpha);
}

float4 difference(float4 base, float4 blend, float alpha)
{
	return lerp(base, abs(base - blend), alpha);
}

float4 colorburn(float4 base, float4 blend, float alpha)
{
	return lerp(base, 1 - ((1 - base) / blend), alpha);
}

float4 colordodge(float4 base, float4 blend, float alpha)
{
	return lerp(base, base / 1 - blend, alpha);
}

float4 desaturate(float4 base, float amount)
{
	float grey = dot(base, float4(0.3, 0.59, 0.11, 0));
	return lerp(grey, base, amount);
}

float2 pixelate(float2 uv, float2 scale)
{
	return floor(uv * scale) / scale;
}
#endif
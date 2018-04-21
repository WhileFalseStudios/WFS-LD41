Shader "Hidden/CRT Effect"
{
	Properties
	{
		_MainTex ("Rendertarget", 2D) = "white" {}
		_ScreenOverlay("Screen Overlay", 2D) = "white" {}
		_Coefficient ("Coefficient", Float) = -0.15
		_Cube ("Cube", Float) = 0.6
		//_Ca ("Chromatic Abberation", Float) = 0.05
		//_BlurSize ("Gaussian Blur Size", Vector) = (1, 0, 0, 0)
	}

	SubShader
	{
		// No culling or depth
		//Cull Off ZWrite Off ZTest Always

		/*
		//Pass 1: perform a cubic distortion on each channel to get the bleed effect.
		Pass
		{
			Cull Off ZWrite Off ZTest Always
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "CRT.cginc"

			float _Coefficient;
			float _Cube;
			float _Ca;

			//Experimental new chromatic abberation. This version simply shifts the normal uv in a certain direction for each channel.
			fixed4 frag(v2f i) : SV_Target
			{
				float2 uv_r = i.uv;
				float2 uv_g = float2(i.uv.r + _Ca, i.uv.g);
				float2 uv_b = float2(i.uv.r - (_Ca * 1.5), i.uv.g);

				float r = tex2D(_MainTex, uv_g).r;
				float g = tex2D(_MainTex, uv_r).g;
				float b = tex2D(_MainTex, uv_b).b;
				return float4(r, g, b, 0);
			}

			ENDCG
		}
		*/

		//Pass 2: apply a horizontal gaussian blur over the image. This creates the CRT-like artifact.
			/*
		Pass
		{
			Cull Off ZWrite Off ZTest Always
			Blend Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "CRT.cginc"

			float4 _BlurSize;

			//https://github.com/Jam3/glsl-fast-gaussian-blur/blob/master/9.glsl
			float4 gaus5(sampler2D img, float2 uv, float2 res, float2 dir)
			{
				float4 col = float4(0, 0, 0, 0);
				float2 off1 = float2(1.3846153846, 1.3846153846) * dir;
				float2 off2 = float2(3.2307692308, 3.2307692308) * dir;
				col += tex2D(img, uv) * 0.2270270270;
				col += tex2D(img, uv + (off1 / res)) * 0.3162162162;
				col += tex2D(img, uv - (off1 / res)) * 0.3162162162;
				col += tex2D(img, uv + (off2 / res)) * 0.0702702703;
				col += tex2D(img, uv - (off2 / res)) * 0.0702702703;
				return col;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return gaus5(_MainTex, i.uv, float2(_ScreenParams.x, _ScreenParams.y), float2(_BlurSize.r, _BlurSize.g));
			}
			ENDCG
		}
		*/
		
		//Pass 3: apply the overlay effects.
		Pass
		{
			Cull Off ZWrite Off ZTest Always
			Blend Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#include "CRT.cginc"

			sampler2D _ScreenOverlay;
			float _Coefficient;
			float _Cube;
			float _Ca;
			
			fixed4 frag (v2f i) : SV_Target
			{														
				float2 uvd = distort(_Coefficient, _Cube, i.uv);				

				float ovl = tex2D(_ScreenOverlay, uvd).a;
				float4 col = tex2D(_MainTex, uvd);
				return col * ovl;
			}
			ENDCG
		}
	}
}
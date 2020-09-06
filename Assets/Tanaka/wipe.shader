// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/wipe"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_HoleCenterX("HoleCenterX", float) = 0.5
		_HoleCenterY("HoleCenterY", float) = 0.5
		_Radius("Radius", float) = 0.5
	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

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
				float _HoleCenterX;
				float _HoleCenterY;
				float _Radius;

				fixed4 frag(v2f i) : SV_Target
				{
					float2 pos = i.uv * _ScreenParams.xy;

					if (distance(pos.xy, fixed2(_HoleCenterX, _HoleCenterY)) < _Radius) {
						discard;
					}
					return fixed4(0, 0, 0, 1);
				}
				ENDCG
			}
		}
}
Shader "Custom/MultipleWaves"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _Parameters1 ("(Kx, Kz, A, w)", Vector) = (0.1,0.1,1,4) // <(�.�<)
        _Parameters2 ("(Kx, Kz, A, w)", Vector) = (0.2,0.1,0.25,4) // <(�.�<)

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float4 _Parameters1, _Parameters2;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float3 Wave(float4 parameters, float3 p, inout float3 tangent, inout float3 binormal)
        {
            float3 k = float3(parameters.x, 0, parameters.y);
            float A = parameters.z;
            float w = parameters.w;
            float3 r = float3(p.x, 0, p.z);
            float t = _Time.y;
            float f = dot(k,r) - w * t;

            tangent += float3(1, k.x * A * cos(f), 0);
            binormal += float3(0, k.z * A * cos(f), 1);

            return float3(p.x, A * sin (f), p.z);
        }

        // (v�.�v)
        void vert(inout appdata_full vertexData)
        {
			float3 gridPoint = vertexData.vertex.xyz;
			float3 tangent = 0;
			float3 binormal = 0;
			float3 p = gridPoint;
			p += Wave(_Parameters1, gridPoint, tangent, binormal);
			p += Wave(_Parameters2, gridPoint, tangent, binormal);
			float3 normal = normalize(cross(binormal, tangent));
			vertexData.vertex.xyz = p;
			vertexData.normal = normal;
		}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

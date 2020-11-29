﻿Shader "Custom/Outline"
{
    Properties
    {
        _MainTex("Main Texture",2D)="black"{}
        _SceneTex("Scene Texture",2D)="black"{}
        _kernel("Gauss Kernel",Vector)=(0,0,0,0)
        _kernelWidth("Gauss Kernel",Float)=1
    }
    SubShader 
    {
        // Horizontal blur
        Pass 
        {
            CGPROGRAM
            float kernel[21];
            float _kernelWidth;
            sampler2D _MainTex;    
            sampler2D _SceneTex;
            float2 _MainTex_TexelSize;
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct v2f 
            {
                float4 pos : SV_POSITION;
                float2 uvs : TEXCOORD0;
            };
            v2f vert (appdata_base v) 
            {
                v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uvs = o.pos.xy / 2 + 0.5;
                return o;
            }
                          
            float4 frag(v2f i) : COLOR 
            {
                int NumberOfIterations=_kernelWidth;
				
                float TX_x=_MainTex_TexelSize.x;
                float TX_y=_MainTex_TexelSize.y;
                float ColorIntensityInRadius=0;

                for(int k=0;k<NumberOfIterations;k+=1)
                {
                    ColorIntensityInRadius+=kernel[k]*tex2D(
                        _MainTex, 
                        float2
                        (
                            i.uvs.x+(k-NumberOfIterations/2)*TX_x,
                            i.uvs.y
                        )
                    ).r;
                }
                return ColorIntensityInRadius;
            }
            ENDCG
        }

        GrabPass{}
		
		// Vertical blur
        Pass 
        {
            CGPROGRAM
            float kernel[21];
            float _kernelWidth;       
            sampler2D _MainTex;    
            sampler2D _SceneTex;
            sampler2D _GrabTexture;
            float2 _GrabTexture_TexelSize;
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct v2f 
            {
                float4 pos : SV_POSITION;
                float2 uvs : TEXCOORD0;
            };
            v2f vert (appdata_base v) 
            {
                v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
                o.uvs = o.pos.xy / 2 + 0.5;
                 
                return o;
            }
            float4 frag(v2f i) : COLOR 
            {
                float TX_x=_GrabTexture_TexelSize.x;
                float TX_y=_GrabTexture_TexelSize.y;

                if(tex2D(_MainTex,i.uvs.xy).r>0)
                {
                    return tex2D(_SceneTex,i.uvs.xy);
                }

                int NumberOfIterations=_kernelWidth;
                float4 ColorIntensityInRadius=0;

                for(int k=0;k < NumberOfIterations;k+=1)
                {
                    ColorIntensityInRadius+=kernel[k]*tex2D(
                        _GrabTexture,
                        float2
                        (
                            i.uvs.x,
                            1-i.uvs.y+(k-NumberOfIterations/2)*TX_y
                        )
                    );
                }
                half4 color= tex2D(_SceneTex,i.uvs.xy)+ColorIntensityInRadius*half4(0, 0.7, 1, 1);
                return color;
            }

            ENDCG
        }
    }
}

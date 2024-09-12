Shader "Unlit/Flammes_Shader"
{
    Properties
    {
        _Color1 ("Lava Color 1", Color) = (1, 0.2, 0, 1) // Couleur de base (rouge/orange)
        _Color2 ("Lava Color 2", Color) = (1, 1, 0, 1)   // Couleur secondaire (jaune)
        _Speed ("Flow Speed", Float) = 1.0  // Vitesse de l'écoulement de la lave
        _Scale ("Noise Scale", Float) = 1.0 // Échelle du noise
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha // Mode de blending alpha
            ZWrite Off
            Cull Off
            Lighting Off

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

            // Propriétés pour les couleurs et les paramètres du shader
            float4 _Color1;
            float4 _Color2;
            float _Speed;
            float _Scale;

            // Fonction pour générer du bruit procédural
            float noise(float2 uv)
            {
                return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);
            }

            // Fonction pour générer un Perlin Noise amélioré
            float perlinNoise(float2 uv)
            {
                float2 i = floor(uv);
                float2 f = frac(uv);

                float a = noise(i);
                float b = noise(i + float2(1, 0));
                float c = noise(i + float2(0, 1));
                float d = noise(i + float2(1, 1));

                float u = f.x * f.x * (3.0 - 2.0 * f.x);
                float v = f.y * f.y * (3.0 - 2.0 * f.y);

                return lerp(lerp(a, b, u), lerp(c, d, u), v);
            }

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv * _Scale; // Échelle du noise pour ajuster la taille du pattern
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Animation du noise pour simuler l'écoulement
                float2 uv = i.uv;
                uv.x += _Time.y * _Speed;  // Défilement en fonction du temps pour simuler l'écoulement de lave

                // Calcul du bruit procédural
                float noiseValue = perlinNoise(uv);

                // Ajout de variation dans le bruit pour simuler les mouvements de la lave
                float pattern = smoothstep(0.3, 0.7, noiseValue);

                // Mélange des couleurs pour donner de la vie à la lave
                fixed4 color = lerp(_Color1, _Color2, pattern);

                return color;
            }
            ENDCG
        }
    }
}

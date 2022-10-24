using UnityEngine;

namespace DefaultNamespace
{
    public enum Illuminant
    {
        D50,
        D65
    }

    public class TestColor : MonoBehaviour
    {
        
        private static float LinearToSRGB(float channel)
        {
            if (channel > 0.0031308f)
            {
                channel = 1.055f * Mathf.Pow(channel, 1 / 2.4f) - 0.055f;
            }
            else
            {
                channel *= 12.92f;
            }

            return channel;
        }

        public static Color LinearToSRGB(Color col)
        {
            return
                new Color(
                    LinearToSRGB(col.r),
                    LinearToSRGB(col.g),
                    LinearToSRGB(col.b)
                );
        }
 public class LAB
            {
                private const float e = 0.008856f;
                private const float k = 903.3f;

                public float l { get; set; }
                public float a { get; set; }
                public float b { get; set; }

                public LAB(Color col, Illuminant illuminant = Illuminant.D65)
                {
                    Vector3 lab = XYZtoLAB(new XYZ(col, illuminant));
                    l = lab.x;
                    a = lab.y;
                    b = lab.z;
                }

                public LAB(XYZ col)
                {
                    Vector3 lab = XYZtoLAB(col);
                    l = lab.x;
                    a = lab.y;
                    b = lab.z;
                }

                // эта функция и есть нужная нам метрика, но об этом позже
                public float DeltaE(LAB color)
                {
                    return Mathf.Sqrt(Mathf.Pow((this.l - color.l), 2f) + Mathf.Pow((this.a - color.a), 2f) +
                                      Mathf.Pow((this.b - color.b), 2f));
                }
                public static bool AreSimilar(Color color1, Color color2, float delta, Illuminant illuminant = Illuminant.D65) {
                    return (new LAB(color1, illuminant)).DeltaE(new LAB(color2, illuminant)) <= delta;
                }
                public static float GetDelta(Color color1, Color color2, Illuminant illuminant = Illuminant.D65) {
                    return (new LAB(color1, illuminant)).DeltaE(new LAB(color2, illuminant));
                }
                private static float ApplyLABconversion(float value)
                {
                    if (value > e)
                    {
                        value = Mathf.Pow(value, 1.0f / 3.0f);
                    }
                    else
                    {
                        value = (k * value + 16) / 116;
                    }

                    return value;
                }

                private static Vector3 XYZtoLAB(XYZ col)
                {
                    float x = col.x;
                    float y = col.y;
                    float z = col.z;

                    float fx = ApplyLABconversion(x);
                    float fy = ApplyLABconversion(y);
                    float fz = ApplyLABconversion(z);

                    return new Vector3(
                        116.0f * fy - 16.0f,
                        500.0f * (fx - fy),
                        200.0f * (fy - fz)
                    );
                }
                
               
            }
        public class XYZ
        {
            // точки самого яркого цвета - белого в обоих стандартах
            private static readonly Vector3 D50 = new Vector3(0.966797f, 1.0f, 0.825188f);
            private static readonly Vector3 D65 = new Vector3(0.95047f, 1.0f, 1.0883f);

            // цветовые компоненты
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }

            // конструктор от обычного цвета из Unity
            public XYZ(Color col, Illuminant illuminant = Illuminant.D65)
            {
                // первым делом переводим цвет из linear RGB в sRGB с помощью
                // метода, описанного выше
                col = LinearToSRGB(col);

                float r = col.r;
                float g = col.g;
                float b = col.b;

                // в зависимости от стандарта выбираем матрицу и самую яркую точку
                // перемножаем матрицы "вручную", как было описано выше
                // после чего нормализуем значения всех компонент цвета
                switch (illuminant)
                {
                    case Illuminant.D50:
                        // sRGB -> XYZ
                        x = 0.4360747f * r + 0.3850649f * g + 0.1430804f * b;
                        y = 0.2225045f * r + 0.7168786f * g + 0.0606169f * b;
                        z = 0.0139322f * r + 0.0971045f * g + 0.7141733f * b;

                        float D50x = D50.x;
                        float D50y = D50.y;
                        float D50z = D50.z;

                        // Clamping to D50 white point & normalizing them afterwards
                        x = Mathf.Clamp(x, 0f, D50x) / D50x;
                        y = Mathf.Clamp(y, 0f, D50y) / D50y;
                        z = Mathf.Clamp(z, 0f, D50z) / D50z;
                        break;
                    case Illuminant.D65:
                        // sRGB -> XYZ
                        x = 0.4124564f * r + 0.3575761f * g + 0.1804375f * b;
                        y = 0.2126729f * r + 0.7151522f * g + 0.0721750f * b;
                        z = 0.0193339f * r + 0.1191920f * g + 0.9503041f * b;

                        float D65x = D65.x;
                        float D65y = D65.y;
                        float D65z = D65.z;

                        // Clamping to D65 white point & normalizing them afterwards
                        x = Mathf.Clamp(x, 0f, D65x) / D65x;
                        y = Mathf.Clamp(y, 0f, D65y) / D65y;
                        z = Mathf.Clamp(z, 0f, D65z) / D65z;
                        break;
                }
            }

           
        }
    }
}
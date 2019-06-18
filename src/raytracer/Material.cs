// ReSharper disable NonReadonlyMemberInGetHashCode

using System;
using rayTracer.Helpers;

namespace rayTracer
{
    public class Material
    {
        private bool Equals(Material other)
        {
            return Equals(Color, other.Color) && Ambient.AlmostEqual(other.Ambient) &&
                   Diffuse.AlmostEqual(other.Diffuse) &&
                   Specular.AlmostEqual(other.Specular) && Shininess.AlmostEqual(other.Shininess);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Material) obj);
        }

        public Color Lighting(Light light, Tuple position, Tuple eyeV, Tuple normalV)
        {
            var effectiveColor = Color * light.Intensity;
            var lightV = (light.Position - position).Normalise();

            var ambient = effectiveColor * Ambient;

            var lightDotNormal = lightV.Dot(normalV);

            Tuple diffuse, specular;
            var black = new Color(0, 0, 0);
            if (lightDotNormal < 0)
            {
                diffuse = black;
                specular = black;
            }
            else
            {
                diffuse = effectiveColor * Diffuse * lightDotNormal;

                var reflectV = (lightV * -1).Reflect(normalV);
                var reflectDotEye = reflectV.Dot(eyeV);

                if (reflectDotEye <= 0)
                {
                    specular = black;
                }
                else
                {
                    var factor = (float) Math.Pow(reflectDotEye, Shininess);
                    specular = light.Intensity * Specular * factor;
                }
            }

            return new Color(ambient + diffuse + specular);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Color != null ? Color.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ Ambient.GetHashCode();
                hashCode = (hashCode * 397) ^ Diffuse.GetHashCode();
                hashCode = (hashCode * 397) ^ Specular.GetHashCode();
                hashCode = (hashCode * 397) ^ Shininess.GetHashCode();
                return hashCode;
            }
        }

        public Color Color { get; set; } = new Color(1, 1, 1);
        public float Ambient { get; set; } = 0.1f;
        public float Diffuse { get; set; } = 0.9f;
        public float Specular { get; set; } = 0.9f;
        public float Shininess { get; set; } = 200f;
    }
}
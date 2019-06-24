using System;

namespace rayTracer
{
    public class Sphere
    {
        private bool Equals(Sphere other)
        {
            return Id.Equals(other.Id) && Equals(CentrePoint, other.CentrePoint) && Equals(Transform, other.Transform) && Equals(Material, other.Material);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Sphere) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (CentrePoint != null ? CentrePoint.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Transform != null ? Transform.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Material != null ? Material.GetHashCode() : 0);
                return hashCode;
            }
        }

        public Guid Id { get; } = new Guid();

        private Tuple CentrePoint { get; } = Tuple.Point(0, 0, 0);
        public Matrix Transform { get; set; } = Matrix.Identity;
        public Material Material { get; set; } = new Material();

        public Tuple NormalAt(Tuple worldPoint)
        {
            var inverseTransform = Transform.Inverse();

            var objectPoint = inverseTransform * worldPoint;
            var objectNormal = objectPoint - CentrePoint;
            var worldNormal = inverseTransform.Transpose() * objectNormal;
            worldNormal.W = 0;
            return worldNormal.Normalise();
        }
    }
}
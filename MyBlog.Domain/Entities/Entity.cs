using System;

namespace MyBlog.Domain.Entities
{
    /// <summary>
    /// Entity class that provides the common fields for all entity classes.
    /// Cannot be instantiated directly and must be inherited.
    /// </summary>
    public abstract class Entity
    {
        public virtual Guid ID { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }

        protected bool IsTransient
        {
            get
            {
                return Equals(this.ID, default(Guid));
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Entity() { }

        /// <summary>
        /// Compares the ID field of the two objects to determine equality
        /// of the entities that the objects represent.
        /// </summary>
        /// <param name="obj">Comparison object</param>
        /// <returns>Boolean indicating if objects refer to the same entity</returns>
        public override bool Equals(object obj)
        {
            Entity other = obj as Entity;

            if (other == null || this.GetType() != obj.GetType())
                return false;
            else if (this.IsTransient && other.IsTransient)
                return ReferenceEquals(this, other);
            else
                return this.ID.Equals(other.ID);
        }

        /// <summary>
        /// If the object has already been persisted to the database, return the hash
        /// code for its unique identifier - otherwise call the base implementation.
        /// </summary>
        /// <returns>Integer representing a hash code for this entity</returns>
        public override int GetHashCode()
        {
            if (this.IsTransient)
                return base.GetHashCode();
            else
                return ID.GetHashCode();
        }

        /// <summary>
        /// Override the equality operator to use the custom comparison method
        /// for this entity.
        /// </summary>
        /// <param name="x">First entity</param>
        /// <param name="y">Second entity</param>
        /// <returns>Boolean indicating if objects refer to the same entity</returns>
        public static bool operator ==(Entity x, Entity y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Override the equality operator to use the custom comparison method
        /// for this entity.
        /// </summary>
        /// <param name="x">First entity</param>
        /// <param name="y">Second entity</param>
        /// <returns>Boolean indicating if objects do not refer to the same entity</returns>
        public static bool operator !=(Entity x, Entity y)
        {
            return !Equals(x, y);
        }
    }
}

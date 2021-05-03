namespace ApplicationCore.Entity
{
    /// <summary>
    /// Is entity soft deleted ?
    /// </summary>
    public interface ISoftDeleted
    {
        public bool IsDeleted { get; set; }
    }
}

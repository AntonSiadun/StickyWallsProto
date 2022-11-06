public interface ICounter
{
    public float Count { get; }

    public void Decrement();
    public void Increment();
    public void ZeroOut();
}
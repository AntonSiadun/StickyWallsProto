public interface ITimer
{
    public float Time { get; }

    public void Substract(float time);
    public void Add(float time);
    public void Reset();
}
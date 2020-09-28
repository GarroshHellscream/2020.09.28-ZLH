public class TaskWaitFrame : TaskBase
{
    int frames;

    public TaskWaitFrame(int frames)
    {
        this.frames = frames;
    }

    public override void UpdatePerFrame(float deltaTime)
    {
        if (frames <= 0)
        {
            Finish();
            return;
        }
        frames --;
    }
}
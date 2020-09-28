public class TaskWaitTime : TaskBase
{
    float seconds;

    public TaskWaitTime(float seconds)
    {
        this.seconds = seconds;
    }

    public override void UpdatePerFrame(float deltaTime)
    {
        if (seconds <= 0)
        {
            Finish();
            return;
        }
        seconds -= deltaTime;
    }
}
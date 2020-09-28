public class TaskSerial : TaskBase
{
    TaskBase[] taskArray;
    TaskBase currentTask;
    int currentIndex = 0;

    public TaskSerial(TaskBase[] taskArray)
    {
        this.taskArray = taskArray;
        if (taskArray.Length > 0)
        {
            currentTask = taskArray[currentIndex];
        }
    }

    public override void UpdatePerFrame(float deltaTime)
    {
        if (currentTask.IsCompleted)
        {
            currentIndex++;
            if (currentIndex < taskArray.Length)
            {
                currentTask = taskArray[currentIndex];
            }
            else
            {
                Finish();
                return;
            }
        }
        currentTask.UpdatePerFrame(deltaTime);
    }
}
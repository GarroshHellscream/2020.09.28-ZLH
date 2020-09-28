public class TaskParall : TaskBase
{
    TaskBase[] taskArray;
    int completedCount = 0;

    public TaskParall(TaskBase[] taskArray)
    {
        this.taskArray = taskArray;
    }

    public override void UpdatePerFrame(float deltaTime)
    {
        if (completedCount == taskArray.Length)
        {
            Finish();
            return;
        }
        completedCount = 0;
        for(int i = 0; i < taskArray.Length; i++)
        {
            if (taskArray[i].IsCompleted)
            {
                completedCount++;
            }
            else
            {
                taskArray[i].UpdatePerFrame(deltaTime);
            }
        }
    }
}
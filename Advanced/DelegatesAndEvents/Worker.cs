//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    // Create a delegate.
    public delegate void WorkPerformedEventHandler(object sender, WorkPerformedEventArgs e);

    public class Worker
    {
        // Create an events.
        public event System.EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event System.EventHandler WorkCompleted;

        // Create a methods.
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(300);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        // Create a virtual methods for events.
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            // Listeners are attached.
            if (WorkPerformed is System.EventHandler<WorkPerformedEventArgs> del)
            {
                // => Raise Event.
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            // Listeners are attached.
            if (WorkCompleted is System.EventHandler del)
            {
                // => Raise Event.
                del(this, System.EventArgs.Empty);
            }
        }
    }
}
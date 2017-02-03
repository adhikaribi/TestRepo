using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Utitlity.BusinessLogic;

namespace Utility.Applicationutils {
    public  class JobScheduler {
        public static void ScheduleJob(string moduleName){
            // construct a scheduler factory
            var schedFact = new StdSchedulerFactory();
            var sched = schedFact.GetScheduler();
            sched.Start();

            // Create a job here
            var job = JobBuilder.Create<SchedulerJob>()
                    .WithIdentity("ModuleScheduleJob", "JobGroupModule")
                    .Build();

            // create trigger, the job is for everyday 10 am 
            var trigger = TriggerBuilder.Create()
                        .WithIdentity("ModuleScheduleTrigger", "JobGroupModule")
                        .WithCronSchedule("0 00 10 * * ?")
                        .ForJob("ModuleScheduleJob", "JobGroupModule")
                        .Build();

            // Schedule the job using the job and trigger 
            sched.ScheduleJob(job, trigger);
        }
    }

    public class SchedulerJob : IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
             // Do what your job needs to do here
             Task.Run(() => ((IModule)AtkUtils.GetInstance(moduleName))?.Run());
        }
    } 
}
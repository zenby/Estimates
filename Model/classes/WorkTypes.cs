using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.classes
{
    class WorkTypes : ViewModelBase

    {
        private int workId;
        private string workType;

        public int WorkId
        {
            get { return workId; }
            set { Set(nameof(WorkId), ref workId, value); }
        }
        
        public string WorkType
        {
            get { return workType; }
            set { Set(nameof(WorkType), ref workType, value); }
        }

    }
}

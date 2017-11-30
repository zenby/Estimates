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
    class ListOfTheWorks: ViewModelBase
    {
        private int objectId;
        private int complexityCategoryOfWork;
        private float averageCoefficient;
        private float coefficient;
        private int workId;

        public int ObjectId
        {
            get { return objectId; }
            set { Set(nameof(ObjectId), ref objectId, value); }
        }
        public int ComplexityCategoryOfWork
        {
            get { return complexityCategoryOfWork; }
            set { Set(nameof(ComplexityCategoryOfWork), ref complexityCategoryOfWork, value); }
        }
        public float AverageCoefficient
        {
            get { return averageCoefficient; }
            set { Set(nameof(AverageCoefficient), ref averageCoefficient, value); }
        }
        public float Coefficient
        {
            get { return coefficient; }
            set { Set(nameof(Coefficient), ref coefficient, value); }
        }
        public int WorkId
        {
            get { return workId; }
            set { Set(nameof(WorkId), ref workId, value); }
        }
    }
}

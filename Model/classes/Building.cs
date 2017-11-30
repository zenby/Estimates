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
    public class Building : ViewModelBase
    {
        private string contractNumber;
        private string nameOfTheObject;
        private string invNumber;
        private int objectID;
        private DateTime issueDate;
        private float length;
        private float width;
        private float height;
        private int amount;
        private bool isCivil;
        private bool isPreserved;
        private bool isWhileConstruction;
        private bool isMultistory;
        private float storeyHeight;
        private float primalCoefficient;
        private float costOfTheObject;

        public string ContractNumber
        {
            get { return contractNumber; }
            set { Set(nameof(ContractNumber), ref contractNumber, value); }
        }
        public string NameOfTheObject
        {
            get { return nameOfTheObject; }
            set { Set(nameof(NameOfTheObject), ref nameOfTheObject, value); }
        }
        public string InvNumber
        {
            get { return invNumber; }
            set { Set(nameof(InvNumber), ref invNumber, value); }
        }
        public int ObjectID
        {
            get { return objectID; }
            set { Set(nameof(ObjectID), ref objectID, value); }
        }
        public DateTime IssueDate
        {
            get { return issueDate; }
            set { Set(nameof(IssueDate), ref issueDate, value); }
        }
        public float Length
        {
            get { return length; }
            set { Set(nameof(Length), ref length, value); }
        }
        public float Width
        {
            get { return width; }
            set { Set(nameof(Width), ref width, value); }
        }
        public float Height
        {
            get { return height; }
            set { Set(nameof(Height), ref height, value); }
        }
        public int Amount
        {
            get { return amount; }
            set { Set(nameof(Amount), ref amount, value); }
        }
        public bool IsCivil
        {
            get { return isCivil; }
            set { Set(nameof(IsCivil), ref isCivil, value); }
        }
        public bool IsPreserved
        {
            get { return isPreserved; }
            set { Set(nameof(IsPreserved), ref isPreserved, value); }
        }
        public bool IsWhileConstruction
        {
            get { return isWhileConstruction; }
            set { Set(nameof(IsWhileConstruction), ref isWhileConstruction, value); }
        }
        public bool IsMultistory
        {
            get { return isMultistory; }
            set { Set(nameof(IsMultistory), ref isMultistory, value); }
        }
        public float StoreyHeight
        {
            get { return storeyHeight; }
            set { Set(nameof(StoreyHeight), ref storeyHeight, value); }
        }
        public float PrimalCoefficient
        {
            get { return primalCoefficient; }
            set { Set(nameof(PrimalCoefficient), ref primalCoefficient, value); }
        }
        public float CostOfTheObject
        {
            get { return costOfTheObject; }
            set { Set(nameof(CostOfTheObject), ref costOfTheObject, value); }
        }


    }
}

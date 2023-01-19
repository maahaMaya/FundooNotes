using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBl
    {
        public LabelEntity CreateNewLabel(NewLabel newLabel, long UserId);
    }
}

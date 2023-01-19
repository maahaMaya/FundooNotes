using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRl
    {
        public LabelEntity CreateNewLabel(NewLabel newLabel, long UserId);
    }
}

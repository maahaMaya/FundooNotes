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
        public bool DeleteLabel(DeleteLabel deleteLabel, long UserId);
        public IEnumerable<LabelEntity> RetrieveLabel(long UserId);
    }
}

using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRl
    {
        public LabelEntity CreateNewLabel(NewLabel newLabel, long UserId);
        public bool DeleteLabel(DeleteLabel deleteLabel, long UserId);
        public IEnumerable<LabelEntity> RetrieveLabel(long UserId);
        public bool UpdateLabel(UpdateLabel updateLabel, long UserId);
    }
}

using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICollaboratorBl
    {
        public CollabEntity AddCollaborator(AddCollaborator addCollaborator, long UserId);
        public IEnumerable<CollabEntity> RetrieveAllCollaborate(PinTrashArchieveCollab NoteTableId, long UserId);
    }
}

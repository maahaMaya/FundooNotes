using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollaboratorRl
    {
        public CollabEntity AddCollaborator(AddDeleteCollaborator addCollaborator, long UserId);
        public IEnumerable<CollabEntity> RetrieveAllCollaborate(PinTrashArchieveCollab NoteTableId, long UserId);
        public bool DeleteCollaborate(AddDeleteCollaborator deleteCollaborator, long UserId);
    }
}

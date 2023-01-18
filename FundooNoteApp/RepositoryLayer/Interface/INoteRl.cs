using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRl
    {
        public NoteEntity CreateNewNote(NewNote newNote, long UserId);
        public bool UpdateNote(UpdateNote updateNote, long UserId);
        public IEnumerable<NoteEntity> RetrieveNotes(RetriveNote retriveNote, long userId);
        public IEnumerable<NoteEntity> RetrieveAllNotes(long userId);
        public int MoveToTrash(PinTrashArchieve trash, long UserId);
        public bool DeleteNote(PinTrashArchieve delete, long UserId);
        public bool DeleteAllTrashNote(long UserId);
        public bool Delete30DaysTrash(long UserId);
        public int ArchieveNote(PinTrashArchieve archieve, long UserId);
        public int PinNote(PinTrashArchieve pin, long UserId);
        public bool NoteColor(NoteColor noteColor, long UserId);
    }
}

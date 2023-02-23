using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBl
    {
        public NoteEntity CreateNewNote(NewNote newNote, long UserId);
        public bool UpdateNote(UpdateNote updateNote, long UserId);
        public IEnumerable<NoteEntity> RetrieveNotes(RetriveNote retriveNote, long userId);
        public IEnumerable<NoteEntity> RetrieveAllNotesWithoutArchieve(long UserId);
        public IEnumerable<NoteEntity> RetrieveAllNotesWithArchieve(long UserId);
        public IEnumerable<NoteEntity> RetrieveAllNotes(long userId);
        public int MoveToTrash(PinTrashArchieveCollab trash, long UserId);
        public bool DeleteNote(PinTrashArchieveCollab delete, long UserId);
        public bool DeleteAllTrashNote(long UserId);
        public bool Delete30DaysTrash(long UserId);
        public int ArchieveNote(PinTrashArchieveCollab archieve, long UserId);
        public int PinNote(PinTrashArchieveCollab pin, long UserId);
        public bool NoteColor(NoteColor noteColor, long UserId);
        public bool ImageUploadOnCloudinary_UpdateImg(NoteBgImage fileUpload, long UserId);
    }
}

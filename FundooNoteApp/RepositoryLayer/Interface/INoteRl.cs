﻿using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRl
    {
        public NoteEntity CreateNewNote(NewNote newNote, long UserId);
        public IEnumerable<NoteEntity> RetrieveNotes(RetriveNote retriveNote, long userId);
        public IEnumerable<NoteEntity> RetrieveAllNotes(long userId);
        public int MoveToTrash(TrashNote deleteNote, long UserId);
    }
}

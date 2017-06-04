CREATE TABLE [dbo].[Apartment] (
    [ApartmentId]   INT           NOT NULL,
    [Size]          FLOAT (53)    NULL,
    [NumberOfRooms] INT           NULL,
    [MonthlyCharge] FLOAT (53)    NULL,
    [Floor]         INT           NULL,
    [Address]       VARCHAR (100) NULL,
    [PlanPicture]   VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ApartmentId] ASC)
);

CREATE TABLE [dbo].[Change] (
    [ChangeId]    INT           IDENTITY (0, 1) NOT NULL,
    [ApartmentId] INT           NOT NULL,
    [Name]        VARCHAR (50)  NULL,
    [UploadDate]  DATE          NULL,
    [Description] VARCHAR (MAX) NULL,
    [Status]      VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ChangeId] ASC),
    CONSTRAINT [FK_Change_ToApartment] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartment] ([ApartmentId])
);

CREATE TABLE [dbo].[ChangeComment] (
    [CommentId] INT           IDENTITY (0, 1) NOT NULL,
    [ChangeId]  INT           NOT NULL,
    [Comment]   VARCHAR (MAX) NULL,
    [Name]      VARCHAR (50)  NULL,
    [Date]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CONSTRAINT [FK_ChangeComment_ToChange] FOREIGN KEY ([ChangeId]) REFERENCES [dbo].[Change] ([ChangeId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[ChangeDocument] (
    [DocumentId] INT          IDENTITY (0, 1) NOT NULL,
    [ChangeId]   INT          NOT NULL,
    [Document]   VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([DocumentId] ASC),
    CONSTRAINT [FK_ChangeDocument_ToChange] FOREIGN KEY ([ChangeId]) REFERENCES [dbo].[Change] ([ChangeId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Defect] (
    [DefectId]    INT           IDENTITY (0, 1) NOT NULL,
    [ApartmentId] INT           NOT NULL,
    [Name]        VARCHAR (50)  NULL,
    [UploadDate]  DATE          NULL,
    [Description] VARCHAR (MAX) NULL,
    [Status]      VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([DefectId] ASC),
    CONSTRAINT [FK_Defect_ToApartment] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartment] ([ApartmentId])
);

CREATE TABLE [dbo].[DefectComment] (
    [CommentId] INT           IDENTITY (0, 1) NOT NULL,
    [DefectId]  INT           NOT NULL,
    [Comment]   VARCHAR (MAX) NULL,
    [Name]      VARCHAR (50)  NULL,
    [Date]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CONSTRAINT [FK_DefectComment_ToDefect] FOREIGN KEY ([DefectId]) REFERENCES [dbo].[Defect] ([DefectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[DefectPicture] (
    [PictureId] INT           IDENTITY (0, 1) NOT NULL,
    [DefectId]  INT           NOT NULL,
    [Picture]   VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([PictureId] ASC),
    CONSTRAINT [FK_DefectPicture_ToDefect] FOREIGN KEY ([DefectId]) REFERENCES [dbo].[Defect] ([DefectId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[PastUser] (
    [Username]    VARCHAR (30) NOT NULL,
    [ApartmentId] INT          NOT NULL,
    [Password]    VARCHAR (30) NOT NULL,
    [IsBm]        BIT          NOT NULL,
    [FirstName]   VARCHAR (30) NULL,
    [LastName]    VARCHAR (30) NULL,
    [BirthDate]   DATE         NULL,
    [Phone]       VARCHAR (20) NULL,
    [Email]       VARCHAR (50) NULL,
    [Picture]     VARCHAR (50) NULL,
    [MoveInDate]  DATE         NULL,
    [MoveOutDate] DATE         NULL,
    PRIMARY KEY CLUSTERED ([Username] ASC),
    CONSTRAINT [FK_PastUser_ToApartment] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartment] ([ApartmentId])
);

CREATE TABLE [dbo].[Resident] (
    [ResidentId]  INT           IDENTITY (0, 1) NOT NULL,
    [ApartmentId] INT           NOT NULL,
    [FirstName]   VARCHAR (30)  NULL,
    [LastName]    VARCHAR (30)  NULL,
    [BirthDate]   DATE          NULL,
    [Phone]       VARCHAR (20)  NULL,
    [Email]       VARCHAR (50)  NULL,
    [Picture]     VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ResidentId] ASC),
    CONSTRAINT [FK_Resident_ToApartment] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartment] ([ApartmentId])
);

CREATE TABLE [dbo].[User] (
    [Username]    VARCHAR (30)  NOT NULL,
    [ApartmentId] INT           NOT NULL,
    [Password]    VARCHAR (30)  NOT NULL,
    [IsBm]        BIT           NOT NULL,
    [FirstName]   VARCHAR (30)  NULL,
    [LastName]    VARCHAR (30)  NULL,
    [BirthDate]   DATE          NULL,
    [Phone]       VARCHAR (20)  NULL,
    [Email]       VARCHAR (50)  NULL,
    [Picture]     VARCHAR (MAX) NULL,
    [MoveInDate]  DATE          NULL,
    [MoveOutDate] DATE          NULL,
    PRIMARY KEY CLUSTERED ([Username] ASC),
    CONSTRAINT [FK_User_ToApartment] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartment] ([ApartmentId])
);


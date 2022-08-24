USE [dbfinal]
GO

/****** Object: Table [dbo].[AcademicRecord] Script Date: 9/17/2017 10:42:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP TABLE [dbo].[Admin];
GO
DROP TABLE [dbo].[Product];
GO
DROP TABLE [dbo].[Brand];
GO
DROP TABLE [dbo].[Customer_has_Product];
GO
DROP TABLE [dbo].[Customer];
GO

CREATE TABLE [dbo].[Admin] (
    [Id]       INT           NOT NULL,
    [Name]     VARCHAR (50)  NULL,
    [Password] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Brand] (
    [Id]      INT          NOT NULL,
    [Name]    VARCHAR (50) NULL,
    [Country] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customer] (
    [Id]       INT           NOT NULL,
    [Name]     VARCHAR (50)  NULL,
    [Email]    VARCHAR (MAX) NULL,
    [Password] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customer_has_Product] (
    [CustomerId] INT NOT NULL,
    [ProductID]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

CREATE TABLE [dbo].[Product] (
    [Id]          INT          NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Describtion] VARCHAR (50) NOT NULL,
    [price]       FLOAT (53)   NOT NULL,
    [BrandId]     INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fkbrand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id])
);




INSERT INTO [dbo].[Product] (Id, Name, HoursPerWeek, FeeBase, Description) VALUES ('CST0001', 'Web Programming', 4, 450, 'Students learn how to manage their laptop environment to gain the best advantage during their college program and later in the workplace. Create backups, install virus protection, manage files through a basic understanding of the Windows Operating System, install and configure the Windows Operating System, install and manage a virtual machine environment. Explore computer architecture including the functional hardware and software components that are needed to run programs. Finally, study basic numerical systems and operations including Boolean logic.');
INSERT INTO [dbo].[Course] (Code, Title, HoursPerWeek, FeeBase, Description) VALUES ('CST0002', 'Introduction to Computer Programming', 6, 650, 'Learn the fundamental problem-solving methodologies needed in software development, such as structured analysis, structured design, structured programming and introduction to object-oriented programming. Use pseudocode, flowcharting, as well as a programming language to develop solutions to real-world problems of increasing complexity. The basics of robust computer programming, with emphasis on correctness, structure, style and documentation are learned using Java. Theory is reinforced with application by means of practical laboratory assignments.');


INSERT INTO [dbo].[Student] ([Id], [Name]) VALUES (N'S0001', N'Wei Gong')
INSERT INTO [dbo].[Student] ([Id], [Name]) VALUES (N'S0002', N'John Smith')


INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST0001', N'S0001', 70)
INSERT INTO [dbo].[AcademicRecord] ([CourseCode], [StudentId], [Grade]) VALUES (N'CST0002', N'S0001', 90)


INSERT INTO [dbo].[Employee] (name, UserName, password) VALUES ('Wei Gong', 'gongw', 'Password1');
INSERT INTO [dbo].[Employee] (name, UserName, password) VALUES ('John Smith', 'smithj', 'Password1');




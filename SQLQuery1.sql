
-- Creating table 'Action_Plan'
CREATE TABLE [dbo].[Action_Plan] (
    [Action_Plan_ID] int IDENTITY(1,1) NOT NULL,
    [Action_Plan1] nvarchar(50)  NOT NULL
);
GO


-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Category_ID] int IDENTITY(1,1) NOT NULL,
    [Category1] varchar(25)  NOT NULL
);
GO

-- Creating table 'Deficiencies'
CREATE TABLE [dbo].[Deficiencies] (
    [Deficiencies_ID] int IDENTITY(1,1) NOT NULL,
    [Deficiency1] varchar(50)  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [Equipment_ID] int IDENTITY(1,1) NOT NULL,
    [Unit_Number] int  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Description1] varchar(50)  NULL,
    [Num_Of_Belts] int  NULL,
    [Belt_Type] varchar(10)  NULL,
    [Plant_ID] int  NOT NULL,
    [Category_ID] int  NOT NULL
);
GO

-- Creating table 'Headings'
CREATE TABLE [dbo].[Headings] (
    [Heading_ID] int IDENTITY(1,1) NOT NULL,
    [Heading1] varchar(30)  NOT NULL,
    [Categories_Under] varchar(max)  NULL,
    [Category_ID] int  NULL
);
GO

-- Creating table 'Pictures'
CREATE TABLE [dbo].[Pictures] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [heading_ID] int  NULL,
    [equipment_ID] int  NULL,
    [name] varchar(250)  NULL,
    [question_ID] int  NULL,
    [URL] varchar(max)  NULL,
    [DateSubmited] datetime  NULL
);
GO

-- Creating table 'Plants'
CREATE TABLE [dbo].[Plants] (
    [Plant_ID] int IDENTITY(1,1) NOT NULL,
    [Plant_Name] varchar(20)  NOT NULL,
    [Address] varchar(50)  NULL,
    [Phone_Num] varchar(15)  NULL,
    [Postal_Code] varchar(7)  NULL,
    [City] varchar(15)  NOT NULL
);
GO

-- Creating table 'Potential_Action_Plans'
CREATE TABLE [dbo].[Potential_Action_Plans] (
    [Potential_Action_Plans_ID] int IDENTITY(1,1) NOT NULL,
    [Potential_Action_Plan] varchar(50)  NOT NULL,
    [Category_ID] int  NOT NULL
);
GO

-- Creating table 'Potential_Deficiencies'
CREATE TABLE [dbo].[Potential_Deficiencies] (
    [Deficiencies_ID] int IDENTITY(1,1) NOT NULL,
    [Deficiencies] varchar(50)  NOT NULL,
    [Category_ID] int  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [Question_ID] int IDENTITY(1,1) NOT NULL,
    [Question1] nvarchar(250)  NOT NULL,
    [Category_ID] int  NOT NULL,
    [Headings_Under] varchar(max)  NULL
);
GO

-- Creating table 'Results'
CREATE TABLE [dbo].[Results] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Response] bit  NOT NULL,
    [Date_Completed] datetime  NOT NULL,
    [Question_ID] int  NOT NULL,
    [Action_plan] varchar(500)  NULL,
    [deficiency_defect] varchar(500)  NULL,
    [Equipment_ID] int  NOT NULL,
    [heading_ID] int  NOT NULL,
    [tempDate] datetime  NULL
);
GO



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------


-- Creating primary key on [Action_Plan_ID] in table 'Action_Plan'
ALTER TABLE [dbo].[Action_Plan]
ADD CONSTRAINT [PK_Action_Plan]
    PRIMARY KEY CLUSTERED ([Action_Plan_ID] ASC);
GO


-- Creating primary key on [Category_ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Category_ID] ASC);
GO

-- Creating primary key on [Deficiencies_ID] in table 'Deficiencies'
ALTER TABLE [dbo].[Deficiencies]
ADD CONSTRAINT [PK_Deficiencies]
    PRIMARY KEY CLUSTERED ([Deficiencies_ID] ASC);
GO

-- Creating primary key on [Equipment_ID] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([Equipment_ID] ASC);
GO

-- Creating primary key on [Heading_ID] in table 'Headings'
ALTER TABLE [dbo].[Headings]
ADD CONSTRAINT [PK_Headings]
    PRIMARY KEY CLUSTERED ([Heading_ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pictures'
ALTER TABLE [dbo].[Pictures]
ADD CONSTRAINT [PK_Pictures]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Plant_ID] in table 'Plants'
ALTER TABLE [dbo].[Plants]
ADD CONSTRAINT [PK_Plants]
    PRIMARY KEY CLUSTERED ([Plant_ID] ASC);
GO

-- Creating primary key on [Potential_Action_Plans_ID] in table 'Potential_Action_Plans'
ALTER TABLE [dbo].[Potential_Action_Plans]
ADD CONSTRAINT [PK_Potential_Action_Plans]
    PRIMARY KEY CLUSTERED ([Potential_Action_Plans_ID] ASC);
GO

-- Creating primary key on [Deficiencies_ID] in table 'Potential_Deficiencies'
ALTER TABLE [dbo].[Potential_Deficiencies]
ADD CONSTRAINT [PK_Potential_Deficiencies]
    PRIMARY KEY CLUSTERED ([Deficiencies_ID] ASC);
GO

-- Creating primary key on [Question_ID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([Question_ID] ASC);
GO

-- Creating primary key on [ID] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [PK_Results]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------







-- Creating foreign key on [Category_ID] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_Equipment_Category_ID]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([Category_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Equipment_Category_ID'
CREATE INDEX [IX_FK_Equipment_Category_ID]
ON [dbo].[Equipments]
    ([Category_ID]);
GO

-- Creating foreign key on [Category_ID] in table 'Headings'
ALTER TABLE [dbo].[Headings]
ADD CONSTRAINT [FK_Headings_0]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([Category_ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Headings_0'
CREATE INDEX [IX_FK_Headings_0]
ON [dbo].[Headings]
    ([Category_ID]);
GO

-- Creating foreign key on [Category_ID] in table 'Potential_Action_Plans'
ALTER TABLE [dbo].[Potential_Action_Plans]
ADD CONSTRAINT [FK_Potential_Action_Plans_Category_ID]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([Category_ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Potential_Action_Plans_Category_ID'
CREATE INDEX [IX_FK_Potential_Action_Plans_Category_ID]
ON [dbo].[Potential_Action_Plans]
    ([Category_ID]);
GO

-- Creating foreign key on [Category_ID] in table 'Potential_Deficiencies'
ALTER TABLE [dbo].[Potential_Deficiencies]
ADD CONSTRAINT [FK_Potential_Deficiencies_0]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([Category_ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Potential_Deficiencies_0'
CREATE INDEX [IX_FK_Potential_Deficiencies_0]
ON [dbo].[Potential_Deficiencies]
    ([Category_ID]);
GO

-- Creating foreign key on [Category_ID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Questions_0]
    FOREIGN KEY ([Category_ID])
    REFERENCES [dbo].[Categories]
        ([Category_ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Questions_0'
CREATE INDEX [IX_FK_Questions_0]
ON [dbo].[Questions]
    ([Category_ID]);
GO

-- Creating foreign key on [Plant_ID] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_Equipment_Plant_ID]
    FOREIGN KEY ([Plant_ID])
    REFERENCES [dbo].[Plants]
        ([Plant_ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Equipment_Plant_ID'
CREATE INDEX [IX_FK_Equipment_Plant_ID]
ON [dbo].[Equipments]
    ([Plant_ID]);
GO





-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
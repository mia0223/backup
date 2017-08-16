DECLARE @UserCreated VARCHAR(10) = 'seed'

-- Create Locations. DO NOT change the order !!!
INSERT INTO Location (Name, UserCreated) VALUES ('TEKsystems', @UserCreated)					-- Id = 1 (Root)
INSERT INTO Location (Name, ParentId, UserCreated) VALUES ('McGill College', 1, @UserCreated)	-- Id = 2 (Default)
INSERT INTO Location (Name, ParentId, UserCreated) VALUES ('Maisonneuve', 1, @UserCreated)		-- Id = 3

-- Create Projects
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('ADS', 'Adesa', 0, '#ADCBAD','#386238', @UserCreated)     -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('BCB', 'BCBSA', 0, '#C7B8E6','#554D65', @UserCreated)    -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('BNH', 'Bench', 1, '#E5E5E5','#6A6A6A', @UserCreated) -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('CAT', 'CA Tech', 0, '#FFDDAB','#B57A26', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('ET', 'Exact Target', 0, '#E6D8B8','#866D37', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('MAC', 'Macy''s', 0, '#BDE6B8','#41713D', @UserCreated) -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('MAY', 'Mayo', 0, '#FAC982','#8D5C17', @UserCreated) -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('OFF', 'Office', 1, '#F0F2CD','#6C764E', @UserCreated) -- share point
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('OB', 'On Boarding', 1, '#D8FFD3','#62915E', @UserCreated) -- share point
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('OPS', 'Ops', 1, '#DCE6BA','#626C45', @UserCreated) -- share point
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('RZ', 'Redzone', 1, '#E0E8FF','#727DAF', @UserCreated) -- share point
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('SCR', 'Scripps', 0, '#B8DFE6','#276E7B', @UserCreated) -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('SP', 'Seat Plan', 1, '#A7BFF5','#505D98', @UserCreated) -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('SHFW', 'Shiftwise', 0, '#DBBFD4','#6E3A60', @UserCreated) -- both
-- Sitecore becomes bench
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('TEKC', 'TEK.com', 0, '#E6B8B8','#715959', @UserCreated) -- both
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('TRP', 'TRP', 0, '#FAE09A','#8B6E22', @UserCreated) -- inconsistent
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('VSP', 'VSP', 0, '#FCF1D3','#96824A', @UserCreated) -- inconsistent
-- Not in share point
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('ALG', 'Allegis', 1, '#8CCE8C', '#1F5C1F', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('ANT', 'Anthem', 0, '#96DE8A', '#406A39', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('BW', 'Best Western', 0, '#96E1EF', '#206C83', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('CC', 'Cleveland Clinic', 0, '#91F0D7', '#237660', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('DRCS', 'DRCS', 0, '#B8D6E6', '#2E759A', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('FP', 'Freedompay', 0, '#DBF2FF', '#5589A2',@UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('HIT', 'Hitachi', 0, '#AFE0D3', '#235C4D', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('HNT', 'Huntsman', 1, '#CBFDEF', '#458E77', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('KCS', 'KCSOS', 1, '#ED7D7D', '#764141', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('KPMG', 'KPMG', 1, '#DBBFD4', '#6E3A60',@UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('PH', 'Patient History', 1, '#FCD7F2', '#806277', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('TRP5', 'T. Rowe Price 529', 1, '#F0A6A6', '#764141', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('TRPS', 'T. Rowe Price Salesforce', 1, '#F0A6A6', '#764141', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('TEKs', 'TEKsystems', 1, '#FFE5D0', '#9F7047', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('VSPc', 'VSP - Claim', 1, '#FFDBDB', '#806E6E', @UserCreated)
INSERT INTO Project (Name, Description, Internal, BackgroundColor, ForegroundColor, UserCreated) VALUES ('VSPe', 'VSP - Eyefinity', 1, '#FFDBDB', '#806E6E', @UserCreated)

-- Create Employee
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Tamer', 'Abu-Haltam', 'tabuhalt@teksystems.com', 2, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Diana', 'Firdjanova', 'dfirdjan@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Gabriel', 'Hernandez', 'ghernand@teksystems.com', 12, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Mykola', 'Dolmatov', 'mdolmato@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sebastien', 'Moulin', 'smoulin@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Anton', 'Burov', 'aburov@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Dang Khoa', 'Do', 'ddo@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Manish', 'Chugh', 'mchugh@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Mojdeh', 'Golmohammadi', 'mgolmoha@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sebastien', 'Boissonneault', 'sboisson@teksystems.com', 15, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Emilio', 'Prato', 'eprato@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Fahimeh', 'Kerachian', 'fakerach@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Nicole', 'Calinoiu', 'ncalinoi@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Rhys', 'Parry', 'rparry@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Mathieu', 'Lafond', 'mlafond@teksystems.com', 9, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Quan', 'Liu', 'qliu@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Ralf', 'Schneider', 'rschneid@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Benoit', 'Wickramarachi', 'bwickram@teksystems.com', 7, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jose', 'Navarro', 'jonavarr@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Paul', 'Urban', 'purban@teksystems.com', 15, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Ghazwa', 'Darwiche', 'gdarwich@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Richard', 'Bussiere', 'rbussier@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Valerie', 'Demeule', 'vdemeule@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Marcio Jose', 'Ramos', 'mramos@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Darlene', 'Dentry', 'ddentry@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Gabriel', 'Desjardins', 'gdesjard@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Angelo', 'Dipaolo', 'adipaolo@teksystems.com', 2, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Tofigh', 'Taherinia', 'ttaherin@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sergei', 'Rybakov', 'srybakov@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Chenyang', 'Wang', 'chewang@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Florian', 'Gombert', 'fgombert@teksystems.com', 9, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Licia', 'Azevedo', 'lazevedo@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vyacheslav', 'Botnaru', 'vbotnaru@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Eric', 'Lamontagne', 'elamonta@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Alexandro', 'Velarde', 'avelarde@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Aaron', 'Xi', 'zxi@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vannadine', 'Ven', 'vven@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Nora', 'Burdujoc', 'nburdujo@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Antonio', 'Caligiuri', 'acaligiu@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jean-Nicholas', 'Thomas', 'jeathoma@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Tanya', 'Callocchia', 'tcallocc@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Tenveer', 'Hussain', 'thussain@teksystems.com', 2, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Hong', 'Xu', 'hxu@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Raynold', 'Jean', 'rjean@teksystems.com', 15, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Nidhi', 'Sharma', 'nisharma@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Muhammad', 'Ammar', 'mammar@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Abiola', 'Ogunjimi', 'aogunjim@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Mohamed', 'Kleit', 'mkleit@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sasi', 'Sellathurai', 'ssellath@teksystems.com', 2, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Denis', 'Balazuc', 'dbalazuc@teksystems.com', 12, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Benoit', 'Joly', 'bjoly@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Benoit', 'Campeau', 'bcampeau@teksystems.com', 12, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Deny', 'Collado Coello', 'dcollado@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Daniel', 'Tardif', 'dtardif@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vincent', 'Leduc', 'vleduc@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Safwan', 'El-Jazouli', 'seljazou@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Cherifa', 'Mansoura', 'cmansour@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sergio', 'Romero', 'sromero@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Peter', 'Petropoulos', 'ppetropo@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Cedric', 'Caron', 'ccaron@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Orly', 'Argaman', 'oargaman@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Venkata', 'Sathi', 'vsathi@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Andre', 'Asano', 'aasano@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Juan', 'Cardenas', 'jcardena@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Laurent', 'Fernandez', 'lafernan@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Igor', 'Biba', 'ibiba@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Maria', 'Hatajlo', 'mhatajlo@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Karen', 'Gong', 'kgong@teksystems.com', 9, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Yury', 'Shamne', 'yshamne@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Atheer', 'Hanna', 'ahanna@teksystems.com', 2, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Anne', 'Lizotte', 'alizotte@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Elizer', 'Grinberger', 'egrinber@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vaisha', 'Vyas', 'vvyas@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Lucien', 'Wang', 'ruwang@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Aneesh', 'Potluri', 'apotluri@teksystems.com', 2, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Aleh', 'Autushka', 'aautushk@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Luis', 'Estefan', 'lestefan@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vasudeva', 'Aourpally', 'vaourpal@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Phuc', 'Khoan', 'pkhoan@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Dzvenyslava', 'Siatetska', 'dsiatets@teksystems.com', 15, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Rong', 'Yang', 'ryang@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Bo', 'Dai', 'bdai@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sergey', 'Kovalenko', 'skovalen@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Arran', 'Bartish', 'abartish@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sean', 'Coull', 'scoull@teksystems.com', 15, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jie', 'Xu', 'jxu@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Lou', 'Pelletier', 'lpelleti@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sal', 'Baki', 'sabaki@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Chirag', 'Vyas', 'cvyas@teksystems.com', 10, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Erwin', 'Pant', 'epant@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Seddik', 'Ramdaki', 'sramdani@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jaswanth', 'Paruchuri', 'jparuchu@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Richard', 'Comtois', 'rcomtois@teksystems.com', 16, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Francois', 'Langlois', 'flangloi@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Linda', 'Zenebisis', 'lzenebis@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Eliseu', 'Baldo', 'ebaldo@teksystems.com', 7, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Behnam', 'Karimi', 'bkarimi@teksystems.com', 5, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Li', 'Zou', 'lzou@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Venepally', 'Abhilash', 'avenepal@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Wassim', 'Abou-Melhem', 'waboumel@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vincent', 'Tortajada', 'vtortaja@teksystems.com', 7, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Maria', 'Quintana', 'mquintan@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Arvind', 'Kumar', 'arvkumar@teksystems.com', 6, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Bruce', 'Kerney', 'bkearney@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Christine', 'Cunningham', 'ccunning@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Peter', 'Aernoudts', 'paernoud@teksystems.com', 12, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Patel', 'Tarang', 'tpatel@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vithi', 'Sellathurai', 'vsellath@teksystems.com', 11, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'John', 'Gammon', 'jgammon@teksystems.com', 12, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Thomas', 'Joubin', 'tjoubin@teksystems.com', 6, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Deyvisson', 'Oliveira', 'doliveir@teksystems.com', 6, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Kasi', 'Gollapudi', 'kgollapu@teksystems.com', 7, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Erik', 'Trepanier', 'ertrepan@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Tito', 'Matthew', 'tmathew@teksystems.com', 15, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Elizabeth', 'Gagne', 'egagne@teksystems.com', 12, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Nicolas', 'Richard', 'nirichar@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Georges', 'Fadous', 'gfadous@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Stan', 'Wroblewski', 'swroblew@teksystems.com', 7, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'David', 'Caya', 'dcaya@teksystems.com', 7, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Phillipe', 'Mirza', 'pmirza@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Patrick', 'Guindon-Slater', 'pguindon@teksystems.com', 4, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Lubana', 'Amarbir Singh', 'alubana@teksystems.com', 4, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Flavius', 'Costa', 'fcosta@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Bruno', 'Ribeiro', 'bribeiro@teksystems.com', 6, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Tatiana', 'Bogatchkina', 'tbogatch@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Vyacheslav', 'Kostin', 'kvyaches@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Amanda', 'Baldwin', 'abaldwin@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sunil', 'Rathod', 'srathod@teksystems.com', 14, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sylvain', 'Barbot', 'sbarbot@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Don', 'Vaillancourt', 'dovailla@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Ariella', 'Baston', 'abaston@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Eric', 'Langlais', 'elanglai@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Paul', 'Moore', 'pmoore@teksystems.com', 17, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Andy', 'Sharma', 'absharma@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'JP', 'Leblanc', 'jleblanc@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Frederic', 'Filiatrault', 'ffiliatr@teksystems.com', 12, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jean-Francois', 'Lemire', 'jlemire@teksystems.com', 8, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jason', 'Cote', 'jcote@teksystems.com', 8, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Steven', 'McGurn', 'smcgurn@teksystems.com', 8, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Sam', 'Malek', 'oabdelma@teksystems.com', 8, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jeannie', 'Riel', 'jriel@teksystems.com', 8, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Ramesh', 'Adusumili', 'radusumi@teksystems.com', 1, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Jack', 'Azoulay', 'jazoulay@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Ashraf', 'Abdelshakour', 'aabdelsh@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Yacine', 'Belala', 'ybelala@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Eyad', 'Chikh-ibrahim', 'echikh@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Assen', 'Garbev', 'agarbev@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Martin', 'Godin', 'mgodin@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Poonam', 'Kumar', 'pokumar@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Mihai', 'Micu', 'mmicu@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Oksana', 'Poliarush', 'opoliaru@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Navneet', 'Rayat', 'nrayat@teksystems.com', 13, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Michel', 'Charlton', 'mcharlto@teksystems.com', 3, @UserCreated )
INSERT INTO Employee (FirstName, LastName, Email, ProjectId, UserCreated) VALUES ( 'Bhuvan', 'Jani', 'bjani@teksystems.com', 3, @UserCreated )

-- Create Transit Seats with default value for seat.Number: NEXT VALUE FOR TransitSeatNumber
CREATE SEQUENCE TransitSeatNumber START WITH 9000 MINVALUE 9000
ALTER TABLE Seat ADD CONSTRAINT SeatNum DEFAULT cast(NEXT VALUE FOR TransitSeatNumber as int) FOR Number
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,144)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,145)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,146)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,148)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,149)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,150)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,151)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,153)
INSERT INTO Seat (LocationId, UserCreated, Transit,EmployeeId) VALUES (1, @UserCreated, 1,154)
INSERT INTO Seat (LocationId, UserCreated, Transit) VALUES (1, @UserCreated, 1)
INSERT INTO Seat (LocationId, UserCreated, Transit) VALUES (1, @UserCreated, 1)
INSERT INTO Seat (LocationId, UserCreated, Transit) VALUES (1, @UserCreated, 1)

-- Create Permanent Seats
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 1, @UserCreated, 1463, 716, 55);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 2, @UserCreated, 1463, 649, 40);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 3, @UserCreated, 1463, 582, 54);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 4, @UserCreated, 1353, 716, 25);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 5, @UserCreated, 1353, 649, 67);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 6, @UserCreated, 1353, 583, 13);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 7, @UserCreated, 1243, 716, 64);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 8, @UserCreated, 1243, 649, 14);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 9, @UserCreated, 1243, 583, 57);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 10, @UserCreated, 1133, 716, 73);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 11, @UserCreated, 1133, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 12, @UserCreated, 1133, 583, 4);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 13, @UserCreated, 1023, 716, 22);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 14, @UserCreated, 1023, 649, 19);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 15, @UserCreated, 1023, 583, 45);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 16, @UserCreated, 913, 716, 21);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 17, @UserCreated, 913, 649, 53);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 18, @UserCreated, 913, 583, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 19, @UserCreated, 803, 716, 17);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 20, @UserCreated, 803, 649, 51);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 21, @UserCreated, 803, 583, 78);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 22, @UserCreated, 693, 716, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 23, @UserCreated, 693, 649, 91);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 24, @UserCreated, 693, 583, 24);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 25, @UserCreated, 583, 716, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 26, @UserCreated, 583, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 27, @UserCreated, 583, 583, 38);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 28, @UserCreated, 473, 716, 35);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 29, @UserCreated, 473, 649, 34);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 30, @UserCreated, 473, 583, 63);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 31, @UserCreated, 363, 716, 58);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 32, @UserCreated, 363, 649, 48);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 33, @UserCreated, 363, 583, 7);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 34, @UserCreated, 253, 716, 66);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 35, @UserCreated, 253, 649, 74);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 36, @UserCreated, 253, 583, 108);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 37, @UserCreated, 142, 716, 12);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 38, @UserCreated, 142, 649, 9);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 39, @UserCreated, 142, 583, 152);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 40, @UserCreated, 33, 716, 95);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 41, @UserCreated, 33, 649, 29);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 42, @UserCreated, 33, 583, 71);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 43, @UserCreated, 1463, 502, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 44, @UserCreated, 1353, 502, 147);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 45, @UserCreated, 1243, 502, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 46, @UserCreated, 1133, 502, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 47, @UserCreated, 1023, 502, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 48, @UserCreated, 803, 502, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 49, @UserCreated, 693, 502, 41);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 50, @UserCreated, 583, 502, 47);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 51, @UserCreated, 473, 502, 77);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 52, @UserCreated, 473, 435, 88);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 53, @UserCreated, 583, 435, 90);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 54, @UserCreated, 693, 435, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 55, @UserCreated, 803, 435, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 56, @UserCreated, 1023, 435, 143);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 57, @UserCreated, 1133, 435, 46);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 58, @UserCreated, 1243, 435, 30);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 59, @UserCreated, 1353, 435, 5);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 60, @UserCreated, 1463, 435, 83);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 61, @UserCreated, 1463, 368, 11);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 62, @UserCreated, 1353, 368, 60);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 63, @UserCreated, 1243, 368, 82);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 64, @UserCreated, 1133, 368, 69);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 65, @UserCreated, 1023, 368, 86);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 66, @UserCreated, 1023, 301, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 67, @UserCreated, 1133, 301, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 68, @UserCreated, 1243, 301, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 69, @UserCreated, 1353, 301, 92);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 70, @UserCreated, 1463, 301, 8);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 71, @UserCreated, 1463, 221, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 72, @UserCreated, 1463, 154, 68);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 73, @UserCreated, 1463, 87, 31);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 74, @UserCreated, 1463, 20, 61);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 75, @UserCreated, 1353, 221, 33);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 76, @UserCreated, 1353, 154, 23);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 77, @UserCreated, 1353, 87, 15);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 78, @UserCreated, 1353, 20, 37);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 79, @UserCreated, 1243, 221, 76);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 80, @UserCreated, 1243, 154, 6);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 81, @UserCreated, 1243, 87, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 82, @UserCreated, 1243, 20, 62);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 83, @UserCreated, 1133, 221, 84);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 84, @UserCreated, 1133, 154, 26);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 85, @UserCreated, 1133, 87, 32);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(2, 86, @UserCreated, 1133, 20, 93);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 101, @UserCreated, 33, 716, 121);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 102, @UserCreated, 33, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 103, @UserCreated, 33, 582, 122);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 104, @UserCreated, 33, 515, 123);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 105, @UserCreated, 143, 716, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 106, @UserCreated, 143, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 107, @UserCreated, 143, 582, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 108, @UserCreated, 143, 515, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 109, @UserCreated, 253, 716, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 110, @UserCreated, 253, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 111, @UserCreated, 253, 582, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 112, @UserCreated, 253, 515, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 113, @UserCreated, 363, 716, 111);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 114, @UserCreated, 363, 649, 110);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 115, @UserCreated, 363, 582, 103);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 116, @UserCreated, 363, 515, 124);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 117, @UserCreated, 473, 716, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 118, @UserCreated, 473, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 119, @UserCreated, 473, 582, 117);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 120, @UserCreated, 473, 515, 100);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 121, @UserCreated, 583, 716, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 122, @UserCreated, 583, 649, 105);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 123, @UserCreated, 583, 582, 99);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 124, @UserCreated, 583, 515, 120);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 125, @UserCreated, 693, 716, 89);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 126, @UserCreated, 693, 649, 113);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 127, @UserCreated, 693, 582, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 128, @UserCreated, 693, 515, 79);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 129, @UserCreated, 803, 716, 27);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 130, @UserCreated, 803, 649, 1);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 131, @UserCreated, 803, 582, 49);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 132, @UserCreated, 803, 515, 75);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 133, @UserCreated, 913, 716, 42);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 134, @UserCreated, 913, 649, 70);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 135, @UserCreated, 913, 582, 39);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 136, @UserCreated, 913, 515, 125);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 137, @UserCreated, 1023, 716, 65);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 138, @UserCreated, 1023, 649, 126);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 139, @UserCreated, 1023, 582, 94);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 140, @UserCreated, 1023, 515, 28);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 141, @UserCreated, 1133, 716, 59);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 142, @UserCreated, 1133, 649, 56);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 143, @UserCreated, 1133, 582, 43);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 144, @UserCreated, 1133, 515, 16);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 145, @UserCreated, 1243, 716, 2);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 146, @UserCreated, 1243, 649, 127);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 147, @UserCreated, 1243, 582, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 148, @UserCreated, 1243, 515, 128);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 149, @UserCreated, 1353, 716, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 150, @UserCreated, 1353, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 151, @UserCreated, 1353, 582, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 152, @UserCreated, 1353, 515, 129);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 153, @UserCreated, 1463, 716, 114);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 154, @UserCreated, 1463, 649, 20);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 155, @UserCreated, 1463, 582, 10);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 156, @UserCreated, 1463, 515, 44);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 157, @UserCreated, 1573, 716, 80);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 158, @UserCreated, 1573, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 159, @UserCreated, 1573, 582, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 160, @UserCreated, 1573, 515, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 161, @UserCreated, 1683, 716, 85);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 162, @UserCreated, 1683, 649, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 163, @UserCreated, 1683, 582, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 164, @UserCreated, 1683, 515, 97);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 165, @UserCreated, 1463, 358, 130);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 166, @UserCreated, 1463, 291, 131);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 167, @UserCreated, 1463, 224, 132);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 168, @UserCreated, 1463, 157, 133);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 169, @UserCreated, 1353, 358, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 170, @UserCreated, 1353, 291, 116);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 171, @UserCreated, 1353, 224, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 172, @UserCreated, 1353, 157, 81);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 173, @UserCreated, 1243, 358, 87);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 174, @UserCreated, 1243, 291, 134);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 175, @UserCreated, 1243, 224, 135);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 176, @UserCreated, 1243, 157, 102);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 177, @UserCreated, 1133, 358, 104);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 178, @UserCreated, 1133, 291, 98);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 179, @UserCreated, 1133, 224, 72);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 180, @UserCreated, 1133, 157, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 181, @UserCreated, 1023, 358, 118);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 182, @UserCreated, 1023, 291, 112);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 183, @UserCreated, 1023, 224, 18);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 184, @UserCreated, 1023, 157, 119);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 185, @UserCreated, 913, 358, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 186, @UserCreated, 913, 291, 96);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 187, @UserCreated, 913, 224, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 188, @UserCreated, 913, 157, 101);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 189, @UserCreated, 693, 425, 52);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 190, @UserCreated, 803, 425, 106);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 191, @UserCreated, 693, 358, 3);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 192, @UserCreated, 803, 358, 115);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 193, @UserCreated, 473, 425, 109);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 194, @UserCreated, 583, 425, 136);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 195, @UserCreated, 473, 358, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 196, @UserCreated, 583, 358, 50);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 197, @UserCreated, 253, 425, 107);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 198, @UserCreated, 363, 425, 36);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 199, @UserCreated, 253, 358, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 200, @UserCreated, 363, 358, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 201, @UserCreated, 33, 425, 142);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 202, @UserCreated, 143, 425, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 203, @UserCreated, 33, 358, null);
INSERT INTO Seat(LocationId, Number, UserCreated, Row, Col, EmployeeId) VALUES(3, 204, @UserCreated, 143, 358, null);
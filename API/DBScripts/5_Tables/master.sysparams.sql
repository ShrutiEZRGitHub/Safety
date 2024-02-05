CREATE TABLE IF NOT EXISTS master.sysparams(
	uin SERIAL,
	systype TEXT COLLATE public.caseinsensitive PRIMARY KEY,
	sysvalue JSONB,
	createdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modifieddate TIMESTAMP,
	createdby INT NOT NULL,
	modifiedby INT,
	lastmodifiedby VARCHAR(100)
);

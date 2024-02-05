CREATE TABLE IF NOT EXISTS master.usersactivities(
	uin BIGSERIAL PRIMARY KEY,
	tablename TEXT NOT NULL,
	activity TEXT NOT NULL,
	oldvalue JSONB,
	newvalue JSONB,
	createdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modifieddate TIMESTAMP,
	createdby INT NOT NULL,
	modifiedby INT
);

CREATE INDEX IF NOT EXISTS idx_usersactivities ON master.usersactivities USING btree (createdby, tablename, activity);


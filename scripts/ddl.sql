Build started...
Build succeeded.
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE address (
    id_adr uuid NOT NULL,
    street character varying(30) NOT NULL,
    number integer NOT NULL,
    city character varying(30) NOT NULL,
    country character varying(30) NOT NULL,
    zipcode integer NOT NULL,
    CONSTRAINT "PK_address" PRIMARY KEY (id_adr)
);

CREATE TABLE "animalType" (
    "id_animalType" uuid NOT NULL,
    typename character varying(30) NOT NULL,
    breed character varying(30) NOT NULL,
    CONSTRAINT "PK_animalType" PRIMARY KEY ("id_animalType")
);

CREATE TABLE animal (
    id_animal uuid NOT NULL,
    "animalType_id_type" uuid NOT NULL,
    name_a character varying(30) NOT NULL,
    age_a integer NOT NULL,
    desc_a character varying(300) NOT NULL,
    CONSTRAINT "PK_animal" PRIMARY KEY (id_animal),
    CONSTRAINT "FK_animal_animalType_animalType_id_type" FOREIGN KEY ("animalType_id_type") REFERENCES "animalType" ("id_animalType") ON DELETE CASCADE
);

CREATE TABLE photo (
    id_photo uuid NOT NULL,
    photo_url text NOT NULL,
    photo_desc character varying(300) NOT NULL,
    related_animal_id uuid,
    CONSTRAINT "PK_photo" PRIMARY KEY (id_photo),
    CONSTRAINT "FK_photo_animal_AnimalId" FOREIGN KEY (related_animal_id) REFERENCES animal (id_animal)
);

CREATE TABLE account (
    id_acc uuid NOT NULL,
    username character varying(30) NOT NULL,
    email character varying(30) NOT NULL,
    password character varying(30) NOT NULL,
    acc_type integer NOT NULL,
    person_id_person uuid,
    CONSTRAINT "PK_account" PRIMARY KEY (id_acc)
);

CREATE TABLE comment (
    id_comment uuid NOT NULL,
    person_author_c uuid NOT NULL,
    comment_text character varying(300) NOT NULL,
    CONSTRAINT "PK_comment" PRIMARY KEY (id_comment)
);

CREATE TABLE offer (
    id_offer uuid NOT NULL,
    person_author_o uuid NOT NULL,
    type_o integer NOT NULL,
    status_o integer NOT NULL,
    related_post_id uuid,
    CONSTRAINT "PK_offer" PRIMARY KEY (id_offer)
    CONSTRAINT "FK_related_post" FOREIGN KEY (related_post_id) REFERENCES post (id_post)
);

CREATE TABLE review (
    "Id" uuid NOT NULL,
    grade integer NOT NULL,
    comment_r character varying(300) NOT NULL,
    "OfferId" uuid,
    CONSTRAINT "PK_review" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_review_offer_OfferId" FOREIGN KEY ("OfferId") REFERENCES offer (id_offer)
);

CREATE TABLE person (
    id_person uuid NOT NULL,
    name character varying(30) NOT NULL,
    surname character varying(30) NOT NULL,
    phone character varying(30) NOT NULL,
    gender integer NOT NULL,
    birth date NOT NULL,
    address_id_adr uuid NOT NULL,
    "PostId" uuid,
    "RequestId" uuid,
    CONSTRAINT "PK_person" PRIMARY KEY (id_person),
    CONSTRAINT "FK_person_address_address_id_adr" FOREIGN KEY (address_id_adr) REFERENCES address (id_adr) ON DELETE CASCADE
);

CREATE TABLE post (
    id_post uuid NOT NULL,
    person_author_p uuid NOT NULL,
    text_p character varying(300) NOT NULL,
    animal_animal_id uuid NOT NULL,
    creation_date date NOT NULL,
    CONSTRAINT "PK_post" PRIMARY KEY (id_post),
    CONSTRAINT "FK_post_animal_animal_animal_id" FOREIGN KEY (animal_animal_id) REFERENCES animal (id_animal) ON DELETE CASCADE,
    CONSTRAINT "FK_post_person_person_author_p" FOREIGN KEY (person_author_p) REFERENCES person (id_person) ON DELETE CASCADE
);

CREATE TABLE request (
    id_req uuid NOT NULL,
    person_req_author uuid NOT NULL,
    creation_date_req date NOT NULL,
    for_promotion integer NOT NULL,
    against_promotion integer NOT NULL,
    CONSTRAINT "PK_request" PRIMARY KEY (id_req),
    CONSTRAINT "FK_request_person_person_req_author" FOREIGN KEY (person_req_author) REFERENCES person (id_person) ON DELETE CASCADE
);

CREATE TABLE postStates (
    "Id" uuid NOT NULL,
    "StateType" character varying(34) NOT NULL,
    CONSTRAINT "PK_postStates" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_postStates_post_Id" FOREIGN KEY ("Id") REFERENCES post (id_post) ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_account_email" ON account (email);

CREATE INDEX "IX_account_person_id_person" ON account (person_id_person);

CREATE UNIQUE INDEX "IX_account_username" ON account (username);

CREATE INDEX "IX_animal_animalType_id_type" ON animal ("animalType_id_type");

CREATE INDEX "IX_comment_person_author_c" ON comment (person_author_c);

CREATE INDEX "IX_comment_PostId" ON comment ("PostId");

CREATE INDEX "IX_offer_person_author_o" ON offer (person_author_o);

CREATE INDEX "IX_offer_PostId" ON offer ("PostId");

CREATE INDEX "IX_person_address_id_adr" ON person (address_id_adr);

CREATE INDEX "IX_person_PostId" ON person ("PostId");

CREATE INDEX "IX_person_RequestId" ON person ("RequestId");

CREATE INDEX "IX_photo_AnimalId" ON photo ("AnimalId");

CREATE INDEX "IX_post_animal_animal_id" ON post (animal_animal_id);

CREATE INDEX "IX_post_person_author_p" ON post (person_author_p);

CREATE INDEX "IX_request_person_req_author" ON request (person_req_author);

CREATE INDEX "IX_review_OfferId" ON review ("OfferId");

ALTER TABLE account ADD CONSTRAINT "FK_account_person_person_id_person" FOREIGN KEY (person_id_person) REFERENCES person (id_person);

ALTER TABLE comment ADD CONSTRAINT "FK_comment_person_person_author_c" FOREIGN KEY (person_author_c) REFERENCES person (id_person) ON DELETE CASCADE;

ALTER TABLE comment ADD CONSTRAINT "FK_comment_post_PostId" FOREIGN KEY ("PostId") REFERENCES post (id_post);

ALTER TABLE offer ADD CONSTRAINT "FK_offer_person_person_author_o" FOREIGN KEY (person_author_o) REFERENCES person (id_person) ON DELETE CASCADE;

ALTER TABLE offer ADD CONSTRAINT "FK_offer_post_PostId" FOREIGN KEY ("PostId") REFERENCES post (id_post);

ALTER TABLE person ADD CONSTRAINT "FK_person_post_PostId" FOREIGN KEY ("PostId") REFERENCES post (id_post);

ALTER TABLE person ADD CONSTRAINT "FK_person_request_RequestId" FOREIGN KEY ("RequestId") REFERENCES request (id_req);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240630220753_Initial', '8.0.6');

COMMIT;


Build started...
Build succeeded.
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE address (
    id_adr uuid NOT NULL,
    street character varying(30) NOT NULL,
    number integer NOT NULL,
    city character varying(30) NOT NULL,
    country character varying(30) NOT NULL,
    zipcode integer NOT NULL,
    CONSTRAINT "PK_address" PRIMARY KEY (id_adr)
);

CREATE TABLE animal_type (
    id_animal_type uuid NOT NULL,
    typename character varying(30) NOT NULL,
    breed character varying(30) NOT NULL,
    CONSTRAINT "PK_animal_type" PRIMARY KEY (id_animal_type)
);

CREATE TABLE animal (
    id_animal uuid NOT NULL,
    "animalType_id_type" uuid NOT NULL,
    name_a character varying(30) NOT NULL,
    age_a integer NOT NULL,
    desc_a character varying(300) NOT NULL,
    CONSTRAINT "PK_animal" PRIMARY KEY (id_animal),
    CONSTRAINT "FK_animal_animal_type_animalType_id_type" FOREIGN KEY ("animalType_id_type") REFERENCES animal_type (id_animal_type) ON DELETE CASCADE
);

CREATE TABLE photo (
    id_photo uuid NOT NULL,
    photo_url text NOT NULL,
    photo_desc character varying(300) NOT NULL,
    "AnimalId" uuid,
    CONSTRAINT "PK_photo" PRIMARY KEY (id_photo),
    CONSTRAINT "FK_photo_animal_AnimalId" FOREIGN KEY ("AnimalId") REFERENCES animal (id_animal)
);

CREATE TABLE account (
    id_acc uuid NOT NULL,
    username character varying(30) NOT NULL,
    email character varying(30) NOT NULL,
    password character varying(30) NOT NULL,
    acc_type integer NOT NULL,
    person_id_person uuid,
    CONSTRAINT "PK_account" PRIMARY KEY (id_acc)
);

CREATE TABLE comment (
    id_comment uuid NOT NULL,
    person_author_c uuid NOT NULL,
    comment_text character varying(300) NOT NULL,
    "PostId" uuid,
    CONSTRAINT "PK_comment" PRIMARY KEY (id_comment)
);

CREATE TABLE offer (
    id_offer uuid NOT NULL,
    person_author_o uuid NOT NULL,
    type_o integer NOT NULL,
    status_o integer NOT NULL,
    "PostId" uuid,
    CONSTRAINT "PK_offer" PRIMARY KEY (id_offer)
);

CREATE TABLE review (
    "Id" uuid NOT NULL,
    grade integer NOT NULL,
    comment_r character varying(300) NOT NULL,
    "OfferId" uuid,
    CONSTRAINT "PK_review" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_review_offer_OfferId" FOREIGN KEY ("OfferId") REFERENCES offer (id_offer)
);

CREATE TABLE person (
    id_person uuid NOT NULL,
    name character varying(30) NOT NULL,
    surname character varying(30) NOT NULL,
    phone character varying(30) NOT NULL,
    gender integer NOT NULL,
    birth date NOT NULL,
    address_id_adr uuid NOT NULL,
    "PostId" uuid,
    "RequestId" uuid,
    CONSTRAINT "PK_person" PRIMARY KEY (id_person),
    CONSTRAINT "FK_person_address_address_id_adr" FOREIGN KEY (address_id_adr) REFERENCES address (id_adr) ON DELETE CASCADE
);

CREATE TABLE post (
    id_post uuid NOT NULL,
    person_author_p uuid NOT NULL,
    text_p character varying(300) NOT NULL,
    animal_animal_id uuid NOT NULL,
    creation_date date NOT NULL,
    CONSTRAINT "PK_post" PRIMARY KEY (id_post),
    CONSTRAINT "FK_post_animal_animal_animal_id" FOREIGN KEY (animal_animal_id) REFERENCES animal (id_animal) ON DELETE CASCADE,
    CONSTRAINT "FK_post_person_person_author_p" FOREIGN KEY (person_author_p) REFERENCES person (id_person) ON DELETE CASCADE
);

CREATE TABLE request (
    id_req uuid NOT NULL,
    person_req_author uuid NOT NULL,
    creation_date_req date NOT NULL,
    for_promotion integer NOT NULL,
    against_promotion integer NOT NULL,
    CONSTRAINT "PK_request" PRIMARY KEY (id_req),
    CONSTRAINT "FK_request_person_person_req_author" FOREIGN KEY (person_req_author) REFERENCES person (id_person) ON DELETE CASCADE
);

CREATE TABLE postStates (
    "Id" uuid NOT NULL,
    "StateType" character varying(34) NOT NULL,
    CONSTRAINT "PK_postStates" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_postStates_post_Id" FOREIGN KEY ("Id") REFERENCES post (id_post) ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_account_email" ON account (email);

CREATE INDEX "IX_account_person_id_person" ON account (person_id_person);

CREATE UNIQUE INDEX "IX_account_username" ON account (username);

CREATE INDEX "IX_animal_animalType_id_type" ON animal ("animalType_id_type");

CREATE INDEX "IX_comment_person_author_c" ON comment (person_author_c);

CREATE INDEX "IX_comment_PostId" ON comment ("PostId");

CREATE INDEX "IX_offer_person_author_o" ON offer (person_author_o);

CREATE INDEX "IX_offer_PostId" ON offer ("PostId");

CREATE INDEX "IX_person_address_id_adr" ON person (address_id_adr);

CREATE INDEX "IX_person_PostId" ON person ("PostId");

CREATE INDEX "IX_person_RequestId" ON person ("RequestId");

CREATE INDEX "IX_photo_AnimalId" ON photo ("AnimalId");

CREATE INDEX "IX_post_animal_animal_id" ON post (animal_animal_id);

CREATE INDEX "IX_post_person_author_p" ON post (person_author_p);

CREATE INDEX "IX_request_person_req_author" ON request (person_req_author);

CREATE INDEX "IX_review_OfferId" ON review ("OfferId");

ALTER TABLE account ADD CONSTRAINT "FK_account_person_person_id_person" FOREIGN KEY (person_id_person) REFERENCES person (id_person);

ALTER TABLE comment ADD CONSTRAINT "FK_comment_person_person_author_c" FOREIGN KEY (person_author_c) REFERENCES person (id_person) ON DELETE CASCADE;

ALTER TABLE comment ADD CONSTRAINT "FK_comment_post_PostId" FOREIGN KEY ("PostId") REFERENCES post (id_post);

ALTER TABLE offer ADD CONSTRAINT "FK_offer_person_person_author_o" FOREIGN KEY (person_author_o) REFERENCES person (id_person) ON DELETE CASCADE;

ALTER TABLE offer ADD CONSTRAINT "FK_offer_post_PostId" FOREIGN KEY ("PostId") REFERENCES post (id_post);

ALTER TABLE person ADD CONSTRAINT "FK_person_post_PostId" FOREIGN KEY ("PostId") REFERENCES post (id_post);

ALTER TABLE person ADD CONSTRAINT "FK_person_request_RequestId" FOREIGN KEY ("RequestId") REFERENCES request (id_req);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240630221051_Initial', '8.0.6');

COMMIT;



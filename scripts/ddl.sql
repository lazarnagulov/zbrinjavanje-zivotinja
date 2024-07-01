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

CREATE TABLE person (
    id_person uuid NOT NULL,
    name character varying(30) NOT NULL,
    surname character varying(30) NOT NULL,
    phone character varying(30) NOT NULL,
    gender integer NOT NULL,
    birth date NOT NULL,
    address_id_adr uuid NOT NULL,
    CONSTRAINT "PK_person" PRIMARY KEY (id_person),
    CONSTRAINT "FK_person_address_address_id_adr" FOREIGN KEY (address_id_adr) REFERENCES address (id_adr) ON DELETE CASCADE
);

CREATE TABLE animal (
    id_animal uuid NOT NULL,
    animal_type_id_type uuid NOT NULL,
    name_a character varying(30) NOT NULL,
    age_a integer NOT NULL,
    desc_a character varying(300) NOT NULL,
    CONSTRAINT "PK_animal" PRIMARY KEY (id_animal),
    CONSTRAINT "FK_animal_animal_type_animal_type_id_type" FOREIGN KEY (animal_type_id_type) REFERENCES animal_type (id_animal_type) ON DELETE CASCADE
);

CREATE TABLE account (
    id_acc uuid NOT NULL,
    username character varying(30) NOT NULL,
    email character varying(30) NOT NULL,
    password character varying(30) NOT NULL,
    acc_type integer NOT NULL,
    person_id_person uuid,
    CONSTRAINT "PK_account" PRIMARY KEY (id_acc),
    CONSTRAINT "FK_account_person_person_id_person" FOREIGN KEY (person_id_person) REFERENCES person (id_person)
);

CREATE TABLE comment (
    id_comment uuid NOT NULL,
    person_author_c uuid NOT NULL,
    comment_text character varying(300) NOT NULL,
    CONSTRAINT "PK_comment" PRIMARY KEY (id_comment),
    CONSTRAINT "FK_comment_person_person_author_c" FOREIGN KEY (person_author_c) REFERENCES person (id_person) ON DELETE CASCADE
);

CREATE TABLE offer (
    id_offer uuid NOT NULL,
    person_author_o uuid NOT NULL,
    type_o integer NOT NULL,
    status_o integer NOT NULL,
    CONSTRAINT "PK_offer" PRIMARY KEY (id_offer),
    CONSTRAINT "FK_offer_person_person_author_o" FOREIGN KEY (person_author_o) REFERENCES person (id_person) ON DELETE CASCADE
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

CREATE TABLE photo (
    id_photo uuid NOT NULL,
    photo_url text NOT NULL,
    photo_desc character varying(300) NOT NULL,
    "AnimalId" uuid,
    CONSTRAINT "PK_photo" PRIMARY KEY (id_photo),
    CONSTRAINT "FK_photo_animal_AnimalId" FOREIGN KEY ("AnimalId") REFERENCES animal (id_animal)
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

CREATE TABLE review (
    id_review uuid NOT NULL,
    grade integer NOT NULL,
    comment_r character varying(300) NOT NULL,
    "OfferId" uuid,
    CONSTRAINT "PK_review" PRIMARY KEY (id_review),
    CONSTRAINT "FK_review_offer_OfferId" FOREIGN KEY ("OfferId") REFERENCES offer (id_offer)
);

CREATE TABLE vote (
    person_id_voter uuid NOT NULL,
    request_id_voted uuid NOT NULL,
    voted_for boolean NOT NULL,
    CONSTRAINT "PK_vote" PRIMARY KEY (person_id_voter, request_id_voted),
    CONSTRAINT "FK_vote_person_person_id_voter" FOREIGN KEY (person_id_voter) REFERENCES person (id_person) ON DELETE CASCADE,
    CONSTRAINT "FK_vote_request_request_id_voted" FOREIGN KEY (request_id_voted) REFERENCES request (id_req) ON DELETE CASCADE
);

CREATE TABLE post_comments (
    comment_id_comment uuid NOT NULL,
    post_id_post_cmt uuid NOT NULL,
    CONSTRAINT "PK_post_comments" PRIMARY KEY (comment_id_comment, post_id_post_cmt),
    CONSTRAINT "FK_post_comments_comment_comment_id_comment" FOREIGN KEY (comment_id_comment) REFERENCES comment (id_comment) ON DELETE CASCADE,
    CONSTRAINT "FK_post_comments_post_post_id_post_cmt" FOREIGN KEY (post_id_post_cmt) REFERENCES post (id_post) ON DELETE CASCADE
);

CREATE TABLE post_likes (
    person_id_liked uuid NOT NULL,
    post_id_liked uuid NOT NULL,
    CONSTRAINT "PK_post_likes" PRIMARY KEY (person_id_liked, post_id_liked),
    CONSTRAINT "FK_post_likes_person_person_id_liked" FOREIGN KEY (person_id_liked) REFERENCES person (id_person) ON DELETE CASCADE,
    CONSTRAINT "FK_post_likes_post_post_id_liked" FOREIGN KEY (post_id_liked) REFERENCES post (id_post) ON DELETE CASCADE
);

CREATE TABLE post_offers (
    offer_id_offer uuid NOT NULL,
    post_id_post uuid NOT NULL,
    CONSTRAINT "PK_post_offers" PRIMARY KEY (offer_id_offer, post_id_post),
    CONSTRAINT "FK_post_offers_offer_offer_id_offer" FOREIGN KEY (offer_id_offer) REFERENCES offer (id_offer) ON DELETE CASCADE,
    CONSTRAINT "FK_post_offers_post_post_id_post" FOREIGN KEY (post_id_post) REFERENCES post (id_post) ON DELETE CASCADE
);

CREATE TABLE post_state (
    post_id uuid NOT NULL,
    state_type character varying(34) NOT NULL,
    CONSTRAINT "PK_post_state" PRIMARY KEY (post_id),
    CONSTRAINT "FK_post_state_post_Id" FOREIGN KEY (post_id) REFERENCES post (id_post) ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_account_email" ON account (email);

CREATE INDEX "IX_account_person_id_person" ON account (person_id_person);

CREATE UNIQUE INDEX "IX_account_username" ON account (username);

CREATE INDEX "IX_animal_animal_type_id_type" ON animal (animal_type_id_type);

CREATE INDEX "IX_comment_person_author_c" ON comment (person_author_c);

CREATE INDEX "IX_offer_person_author_o" ON offer (person_author_o);

CREATE INDEX "IX_person_address_id_adr" ON person (address_id_adr);

CREATE INDEX "IX_photo_AnimalId" ON photo ("AnimalId");

CREATE INDEX "IX_post_animal_animal_id" ON post (animal_animal_id);

CREATE INDEX "IX_post_person_author_p" ON post (person_author_p);

CREATE INDEX "IX_post_comments_post_id_post_cmt" ON post_comments (post_id_post_cmt);

CREATE INDEX "IX_post_likes_post_id_liked" ON post_likes (post_id_liked);

CREATE INDEX "IX_post_offers_post_id_post" ON post_offers (post_id_post);

CREATE INDEX "IX_request_person_req_author" ON request (person_req_author);

CREATE INDEX "IX_review_OfferId" ON review ("OfferId");

CREATE INDEX "IX_vote_request_id_voted" ON vote (request_id_voted);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240701100756_Initial', '8.0.6');

COMMIT;



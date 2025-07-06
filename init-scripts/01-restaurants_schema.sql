create type restaurant_status as enum ('Active', 'Inactive', 'Deleted');

alter type restaurant_status owner to postgres;

create function update_updated_date_column() returns trigger
    language plpgsql
as
$$
BEGIN
    NEW.UpdatedDate = NOW();
    RETURN NEW;
END;
$$;

alter function update_updated_date_column() owner to postgres;

create table restaurants
(
    id             uuid                                                  not null
        constraint pk_restaurants
            primary key,
    status         restaurant_status default 'Active'::restaurant_status not null,
    creationdate   timestamp         default now()                       not null,
    updateddate    timestamp         default now()                       not null,
    restaurantname varchar(100)                                          not null
        constraint chk_restaurant_name_length
            check (length(TRIM(BOTH FROM restaurantname)) > 0),
    score          numeric(4, 2)
        constraint chk_restaurant_score
            check ((score >= 0.00) AND (score <= 10.00))
);

alter table restaurants
    owner to postgres;

create index idx_restaurants_status
    on restaurants (status);

create index idx_restaurants_name
    on restaurants (restaurantname);

create index idx_restaurants_score
    on restaurants (score);

create index idx_restaurants_creationdate
    on restaurants (creationdate);

create trigger update_restaurants_updated_date
    before update
    on restaurants
    for each row
execute procedure update_updated_date_column();


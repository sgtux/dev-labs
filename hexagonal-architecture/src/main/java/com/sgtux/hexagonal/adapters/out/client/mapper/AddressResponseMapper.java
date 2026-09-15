package com.sgtux.hexagonal.adapters.out.client.mapper;

import org.mapstruct.Mapper;

import com.sgtux.hexagonal.adapters.out.client.response.AddressResponse;
import com.sgtux.hexagonal.application.core.domain.Address;

@Mapper(componentModel = "spring")
public interface AddressResponseMapper {
    Address toAddress(AddressResponse addressResponse);
}

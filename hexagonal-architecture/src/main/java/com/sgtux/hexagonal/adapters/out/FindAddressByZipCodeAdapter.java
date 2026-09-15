package com.sgtux.hexagonal.adapters.out;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.sgtux.hexagonal.adapters.out.client.FindAddressByZipCodeClient;
import com.sgtux.hexagonal.adapters.out.client.mapper.AddressResponseMapper;
import com.sgtux.hexagonal.application.core.domain.Address;
import com.sgtux.hexagonal.application.ports.out.FindAddressByZipCodeOutputPort;

@Component
public class FindAddressByZipCodeAdapter implements FindAddressByZipCodeOutputPort {

    @Autowired
    private FindAddressByZipCodeClient findAddressByZipCodeClient;

    @Autowired
    private AddressResponseMapper addressResponseMapper;

    @Override
    public Address find(String zipCode) {
        var addressResponse = findAddressByZipCodeClient.find(zipCode);
        return addressResponseMapper.toAddress(addressResponse);
    }
}
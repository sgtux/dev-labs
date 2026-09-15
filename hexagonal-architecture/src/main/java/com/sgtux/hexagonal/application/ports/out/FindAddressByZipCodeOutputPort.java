package com.sgtux.hexagonal.application.ports.out;

import com.sgtux.hexagonal.application.core.domain.Address;

public interface FindAddressByZipCodeOutputPort {

    Address find(String zipCode);
}

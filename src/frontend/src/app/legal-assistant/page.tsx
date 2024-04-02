"use client";

import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

import React, { useRef, useState } from 'react';

import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import Badge, { BadgeProps } from '@mui/material/Badge';

import StakeholderList from './stakeholders/page';

// Costs
import HandshakeTwoToneIcon from '@mui/icons-material/HandshakeTwoTone';


export default function LegalAssistant() {
    const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  }));


  console.log(`[LegalAssistant] Rendering.`);
  return (
    <Stack spacing={3}>
      <Item>
        <Paper elevation={0}>
          <StakeholderList />
        </Paper>
      </Item>
      <Item>
        <Paper elevation={0}>
          Cost
        </Paper>
      </Item>
      <Item>
        <Paper elevation={0}>
          Pottential docs
        </Paper>
      </Item>
      <Item>
        <Paper elevation={0}>
          Quick reply
        </Paper>
      </Item>
    </Stack>
  );
}
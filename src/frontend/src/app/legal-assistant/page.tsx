"use client";

import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

import React, { useRef, useState } from 'react';
import { styled, ThemeProvider, createTheme } from '@mui/material/styles';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import Badge, { BadgeProps } from '@mui/material/Badge';

import StakeholderList from './stakeholders/page';
import CostList from './costs/page';
// Costs


export default function LegalAssistant() {
  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(0),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  }));


  console.log(`[LegalAssistant] Rendering.`);
  return (
    <Stack spacing={1}>
      <ThemeProvider
        theme={createTheme({
          components: {
            MuiListItemButton: {
              defaultProps: {
                disableTouchRipple: true,
              },
            },
          },
          palette: {
            mode: 'dark',
            // primary: { main: 'rgb(102, 157, 246)' },
            // background: { paper: 'rgb(5, 30, 52)' },
            primary: { main: '#006BD6' },
            background: { paper: '#006BD6' },
          },
        })}
      >
        <Item>
          <Paper elevation={0}>
            <StakeholderList />
          </Paper>
        </Item>
        <Item>
          <Paper elevation={0}>
            <CostList />
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
      </ThemeProvider>
    </Stack>
  );
}